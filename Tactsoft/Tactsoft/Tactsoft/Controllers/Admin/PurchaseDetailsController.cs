using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class PurchaseDetailsController : Controller
    {
        private readonly IPurchaseDetailsService _purchaseDetailsService;
        private readonly IItemService _itemService;
        private readonly IPurchaseMasterService _purchaseMasterService;
        public PurchaseDetailsController(IPurchaseDetailsService purchaseDetailsService, IItemService itemService, IPurchaseMasterService purchaseMasterService)
        {
            _purchaseDetailsService = purchaseDetailsService;
            _itemService = itemService;
            _purchaseMasterService = purchaseMasterService;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var pd=await _purchaseDetailsService.GetAllAsync(x=>x.Purchase,c=>c.Item);
            return View(pd);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["PurchaseId"] = _purchaseMasterService.Dropdown();
            ViewData["ItemId"] = _itemService.Dropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PurchaseDetail purchaseDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _purchaseDetailsService.InsertAsync(purchaseDetail);
                    TempData["successAlert"] = "Purchase Master Save successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                ViewData["PurchaseId"] = _purchaseMasterService.Dropdown();
                ViewData["ItemId"] = _itemService.Dropdown();
                return View(purchaseDetail);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
