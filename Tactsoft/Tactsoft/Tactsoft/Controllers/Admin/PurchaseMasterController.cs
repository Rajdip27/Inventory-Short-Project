using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class PurchaseMasterController : Controller
    {
        private readonly IPurchaseMasterService _purchaseMasterService;
        public PurchaseMasterController(IPurchaseMasterService purchaseMasterService)
        {
            _purchaseMasterService = purchaseMasterService;
        }

        public async Task< IActionResult> Index()
        {
            var pm =await _purchaseMasterService.GetAllAsync();
            return View(pm);
        }
    }
}
