using BelajarKoneksiDatabase.Contexts;
using BelajarKoneksiDatabase.Models;
using BelajarKoneksiDatabase.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BelajarKoneksiDatabase.Controllers;
public class EmployeeController : Controller
{
    private readonly MyContext context;
    private readonly EmployeeVM employeeVM;
    public EmployeeController(MyContext context)
    {
        this.context = context;
    }
    public IActionResult Index()
    {
        var results = context.Employees
            .Select(e => new EmployeeVM
            {
                NIK = e.NIK,
                FirstName = e.FirstName,
                LastName = e.LastName,
                BirthDate = e.BirthDate,
                Gender = (ViewModels.GenderEnum)e.Gender,
                HireDate = e.HireDate,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
            }).ToList();
        return View(results);
        /*var employees = context.Employees.ToList();
        return View(employees);*/
    }
    public IActionResult Details(string id)
    {
        var employee = context.Employees.Find(id);
        return View(new EmployeeVM
        {
            NIK = employee.NIK,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            Gender = (ViewModels.GenderEnum)employee.Gender,
            HireDate = employee.HireDate,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
        });
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EmployeeVM employee)
    {
        context.Add(new Employee
        {
            NIK = employee.NIK,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            Gender = (Models.GenderEnum)employee.Gender,
            HireDate = employee.HireDate,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber
        });
        var result = context.SaveChanges();
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }
    public IActionResult Edit(string id)
    {
        var employee = context.Employees.Find(id);

        return View(new EmployeeVM
        {
            NIK = employee.NIK,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            BirthDate = employee.BirthDate,
            Gender = (ViewModels.GenderEnum)employee.Gender,
            HireDate = employee.HireDate,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Employee employee)
    {
        context.Entry(employee).State = EntityState.Modified;
        var result = context.SaveChanges();
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    public IActionResult Delete(string id)
    {
        var employee = context.Employees.Find(id);
        return View(employee);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(EmployeeVM employeeVM)
    {
        var employee = context.Employees.Find(employeeVM.NIK);
        context.Remove(employee);
        var result = context.SaveChanges();
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}