using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class PurchaseMasterController : Controller
    {
        private readonly IPurchaseMasterService _purchaseMasterService;
        private readonly ISupplierService _supplierService;
        public PurchaseMasterController(IPurchaseMasterService purchaseMasterService, ISupplierService supplierService)
        {
            _purchaseMasterService = purchaseMasterService;
            _supplierService = supplierService;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var pm =await _purchaseMasterService.GetAllAsync(x=>x.Supplier);
            return View(pm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["SupplierId"] = _supplierService.Dropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PurchaseMaster purchaseMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _purchaseMasterService.InsertAsync(purchaseMaster);
                    TempData["successAlert"] = "Purchase Master Save successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                ViewData["SupplierId"] = _supplierService.Dropdown();
                return View(purchaseMaster);

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
                ViewData["SupplierId"] = _supplierService.Dropdown();
                var Result = await _purchaseMasterService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PurchaseMaster purchaseMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pm = await _purchaseMasterService.FindAsync(purchaseMaster.Id);
                    if (pm != null)
                    {
                        pm.SupplierId= purchaseMaster.Id;
                        pm.Discount = purchaseMaster.Discount;
                        pm.Total= purchaseMaster.Total;
                        pm.PurchaseDate=purchaseMaster.PurchaseDate;

                        await _purchaseMasterService.UpdateAsync(pm);
                        TempData["successAlert"] = "Purchase Master Update successfull.";
                        return RedirectToAction(actionName: nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                ViewData["SupplierId"] = _supplierService.Dropdown();
                return View(purchaseMaster);
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
                ViewData["SupplierId"] = _supplierService.Dropdown();
                var Result = await _purchaseMasterService.FindAsync(x=>x.Id==id,c=>c.Supplier);
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
                ViewData["SupplierId"] = _supplierService.Dropdown();
                var Result = await _purchaseMasterService.FindAsync(x => x.Id == id, c => c.Supplier);
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
                    var it = await _purchaseMasterService.FindAsync(id);
                    if (it != null)
                    {
                        await _purchaseMasterService.DeleteAsync(it);
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
