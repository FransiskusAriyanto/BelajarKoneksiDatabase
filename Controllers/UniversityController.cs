using BelajarKoneksiDatabase.Contexts;
using BelajarKoneksiDatabase.Models;
using BelajarKoneksiDatabase.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BelajarKoneksiDatabase.Controllers;
public class UniversityController : Controller
{
    private readonly MyContext context;
    private readonly UniversityVM universityVM;
    public UniversityController(MyContext context)
    {
        this.context = context;
    }
    public IActionResult Index()
    {
        var universities = context.Universities.ToList();
        return View(universities);
    }
    public IActionResult Details(int id)
    {
        var university = context.Universities.Find(id);
        return View(new UniversityVM
        {
            Id = university.Id,
            Name = university.Name,
        });
        /*var university = context.Universities.Find(id);
        return View(university);*/
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(UniversityVM university)
    {
        context.Add(new University
        {
            Name = university.Name
        });
        var result = context.SaveChanges();
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }
    public IActionResult Edit(int id)
    {
        var university = context.Universities.Find(id);

        return View(new UniversityVM
        {
            Id = university.Id,
            Name = university.Name,
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(UniversityVM university)
    {
        var request = context.Universities.Find(university.Id);
        if (request != null)
        {
            request.Name = university.Name;
        }
        var update = context.SaveChanges();
        if (update > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }
    public IActionResult Delete(int id)
    {
        var university = context.Universities.Find(id);
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(UniversityVM universityVM)
    {
        var university = context.Universities.Find(universityVM.Id);
        context.Remove(university);
        var result = context.SaveChanges();
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}