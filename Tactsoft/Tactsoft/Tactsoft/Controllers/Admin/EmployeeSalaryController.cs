using Microsoft.AspNetCore.Mvc;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EmployeeSalaryController : Controller
    {
        private readonly IEmployeeSalaryTbService _employeeSalaryTbService;
        public EmployeeSalaryController(IEmployeeSalaryTbService employeeSalaryTbService)
        {
            _employeeSalaryTbService = employeeSalaryTbService;
        }

        public async Task< IActionResult> Index()
        {
            var em = await _employeeSalaryTbService.GetAllAsync();
            return View(em);
        }
    }
}
