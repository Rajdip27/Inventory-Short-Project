using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        public ItemController(IItemService itemService, ICategoryService categoryService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
        }

        public async Task< IActionResult> Index()
        {
            var it = await _itemService.GetAllAsync(x=>x.Category);
            return View(it);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = _categoryService.Dropdown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _itemService.InsertAsync(item);
                    TempData["successAlert"] = "Item save successfull.";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(item);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
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
               // ViewData["CategoryId"] = _categoryService.Dropdown();
                var it=await _itemService.FindAsync(id);
                return View(it);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Item item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var it = await _itemService.FindAsync(item.Id);
                    if(it != null)
                    {
                        it.CategoryId=item.CategoryId;
                        it.ItemName=item.ItemName;
                        it.ItemDescription = item.ItemDescription;
                        await _itemService.UpdateAsync(it);
                        TempData["successAlert"] = "Item Update successfull.";
                        return RedirectToAction(actionName: nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                ViewData["CategoryId"] = _categoryService.Dropdown();
                return View(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int ? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                //ViewData["CategoryId"] = _categoryService.Dropdown();
                var it = await _itemService.FindAsync(m=>m.Id==id,c=>c.Category);
                return View(it);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int ? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                //ViewData["CategoryId"] = _categoryService.Dropdown();
                var it = await _itemService.FindAsync(m => m.Id == id, c => c.Category);
                return View(it);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCon(int  id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return NotFound();
                    }
                    var it = await _itemService.FindAsync(id);
                    if(it != null)
                    {
                        await _itemService.DeleteAsync(it);
                        TempData["successAlert"] = "Item Delete successfull.";
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
