using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task< IActionResult> Index()
        {
            var em=await _employeeService.GetAllAsync();
            return View(em);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeTb employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeService.InsertAsync(employee);
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View (employee);

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

                var em = await _employeeService.FindAsync(id);
                return View(em);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeTb employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var em = await _employeeService.FindAsync(employee.Id);
                    if(em != null)
                    {
                        em.EmployeeName = employee.EmployeeName;
                        em.Designation = employee.Designation;
                        em.Basic = employee.Basic;
                        await _employeeService.UpdateAsync(em);
                        return RedirectToAction(actionName: nameof(Index));
                    }
                    else
                    {
                        return NotFound();
                    }
                   
                }
                return View(employee);

            }
            catch (Exception ex)
            {
                return View(ex.Message);
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

                var em = await _employeeService.FindAsync(id);
                return View(em);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
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

                var em = await _employeeService.FindAsync(id);
                return View(em);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCon(int id)
        {
            try
            {
                var em = await _employeeService.FindAsync(id);
                if(em == null)
                {
                    return NotFound();
                }
                await _employeeService.DeleteAsync(em);
                return RedirectToAction(actionName: nameof(Index));

            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

    }
}
