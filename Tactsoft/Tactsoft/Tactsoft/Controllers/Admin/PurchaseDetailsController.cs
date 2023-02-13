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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                ViewData["PurchaseId"] = _purchaseMasterService.Dropdown();
                ViewData["ItemId"] = _itemService.Dropdown();
                var Result = await _purchaseDetailsService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PurchaseDetail purchaseDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pd = await _purchaseDetailsService.FindAsync(purchaseDetail.Id);
                    if (pd != null)
                    {
                       pd.Item=purchaseDetail.Item;
                        pd.Qty=purchaseDetail.Qty;
                        pd.Rate=purchaseDetail.Rate;
                        pd.PurchaseId=purchaseDetail.PurchaseId;

                        await _purchaseDetailsService.UpdateAsync(pd);
                        TempData["successAlert"] = "Purchase Details Update successfull.";
                        return RedirectToAction(actionName: nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                ViewData["PurchaseId"] = _purchaseMasterService.Dropdown();
                ViewData["ItemId"] = _itemService.Dropdown();
                return View(purchaseDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                ViewData["PurchaseId"] = _purchaseMasterService.Dropdown();
                ViewData["ItemId"] = _itemService.Dropdown();
                var Result = await _purchaseDetailsService.FindAsync(x=>x.Id==id,x=>x.Purchase);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                
                var Result = await _purchaseDetailsService.FindAsync(x => x.Id == id, c => c.Purchase);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCon(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    var it = await _purchaseDetailsService.FindAsync(id);
                    if (it != null)
                    {
                        await _purchaseDetailsService.DeleteAsync(it);
                        TempData["successAlert"] = "Purchase Master Delete successfull.";
                        return RedirectToAction(actionName: nameof(Index));

                    }
                    else
                    {
                        return NotFound();
                    }

                }
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
