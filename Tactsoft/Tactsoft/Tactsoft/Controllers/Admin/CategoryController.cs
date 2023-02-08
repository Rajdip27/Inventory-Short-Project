using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task< IActionResult> Index()
        {
            var ct= await _categoryService.GetAllAsync();   
            return View(ct);
        }
    }
}
