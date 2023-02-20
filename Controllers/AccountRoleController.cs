using BelajarKoneksiDatabase.Contexts;
using BelajarKoneksiDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BelajarKoneksiDatabase.Controllers;
public class AccountRoleController : Controller
{
    private readonly MyContext context;
    public AccountRoleController(MyContext context)
    {
        this.context = context;
    }
    public IActionResult Index()
    {
        var accountRoles = context.AccountRoles.ToList();
        return View(accountRoles);
    }
    public IActionResult Details(int id)
    {
        var accountRole = context.AccountRoles.Find(id);
        return View(accountRole);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AccountRole accountRole)
    {
        context.Add(accountRole);
        var result = context.SaveChanges();
        if (result > 0)
            return RedirectToAction(nameof(Index));
        return View();
    }
    public IActionResult Edit(int id)
    {
        var accountRole = context.AccountRoles.Find(id);
        return View(accountRole);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(AccountRole accountRole)
    {
        context.Entry(accountRole).State = EntityState.Modified;
        var result = context.SaveChanges();
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    public IActionResult Delete(int id)
    {
        var accountRole = context.AccountRoles.Find(id);
        return View(accountRole);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        var accountRole = context.AccountRoles.Find(id);
        context.Remove(accountRole);
        var result = context.SaveChanges();
        if (result > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}