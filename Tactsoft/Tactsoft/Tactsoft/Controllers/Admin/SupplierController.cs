using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IItemService _itemService;
        public SupplierController(ISupplierService supplierService, IItemService itemService)
        {
            _supplierService = supplierService;
            _itemService = itemService;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var sup= await _supplierService.GetAllAsync(x=>x.Item);
            return View(sup);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ItemId"] = _itemService.Dropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _supplierService.InsertAsync(supplier);
                    TempData["successAlert"] = "Supplier Save successfull.";
                    return RedirectToAction(actionName:nameof(Index));
                }
                ViewData["ItemId"] = _itemService.Dropdown();
                return View(supplier);

            }catch(Exception ex)
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
                ViewData["ItemId"] = _itemService.Dropdown();
                var Result = await _supplierService.FindAsync(id);
                return View(Result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Supplier  supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var sup = await _supplierService.FindAsync(supplier.Id);
                    if (sup != null)
                    {
                        sup.ItemId = supplier.ItemId;
                        sup.Address = supplier.Address;
                        sup.SupplierName= supplier.SupplierName;
                        sup.Phone= supplier.Phone;  
                        await _supplierService.UpdateAsync(sup);
                        TempData["successAlert"] = "Supplier Update successfull.";
                        return RedirectToAction(actionName: nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                ViewData["ItemId"] = _itemService.Dropdown();
                return View(supplier);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details (int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                ViewData["ItemId"] = _itemService.Dropdown();
                var Result = await _supplierService.FindAsync(m=>m.Id==id,c=>c.Item);
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
                ViewData["ItemId"] = _itemService.Dropdown();
                var Result = await _supplierService.FindAsync(m => m.Id == id, c => c.Item);
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
                    var sp = await _supplierService.FindAsync(id);
                    if (sp != null)
                    {
                        await _supplierService.DeleteAsync(sp);
                        TempData["successAlert"] = "Supplier Delete successfull.";
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
