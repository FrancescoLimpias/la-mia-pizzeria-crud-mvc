using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Seeders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers;
public class PizzaController : Controller
{

    PizzeriaContext context = new PizzeriaContext();

    // GET: PizzaController
    public ActionResult Index()
    {
        return View(
            context.Pizzas
            .Include(pizza => pizza.Category)
            .ToList()
            );
    }

    // GET: PizzaController/Details/5
    public ActionResult Details(long id)
    {
        return View(
            context.Pizzas
            .Where(pizza => pizza.PizzaId == id)
            .Include(pizza => pizza.Category)
            .FirstOrDefault());
    }

    // GET: PizzaController/Create
    public ActionResult Create()
    {
        return View(new PizzaPayload()
        {
            Pizza = new(),
            Categories = context.Categories.ToList(),
        });
    }

    // POST: PizzaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Pizza data)
    {

        if (!ModelState.IsValid)
        {
            return View("Create", new PizzaPayload()
            {
                Pizza = data,
                Categories = context.Categories.ToList(),
            });
        }

        try
        {
            // attempt to create a new pizza
            context.Pizzas.Add(data);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PizzaController/Edit/5
    public ActionResult Edit(long id)
    {
        Pizza? searchedPizza = context.Pizzas.Find(id);

        if (searchedPizza == null)
            return NotFound();

        return View(new PizzaPayload()
        {
            Pizza = searchedPizza,
            Categories = context.Categories.ToList(),
        });
    }

    // POST: PizzaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(long id, Pizza data)
    {

        if (!ModelState.IsValid)
        {
            return View("Edit", new PizzaPayload()
            {
                Pizza = data,
                Categories = context.Categories.ToList(),
            });
        }

        try
        {
            // attempt to create a new pizza
            Pizza? pizzaToEdit = context.Pizzas.Find(id);

            // nullity check
            if (pizzaToEdit == null)
                return NotFound();

            // update pizza's fields
            pizzaToEdit.Name = data.Name;
            pizzaToEdit.Description = data.Description;
            pizzaToEdit.Price = data.Price;
            pizzaToEdit.CategoryId = data.CategoryId;

            // save
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return NotFound();
        }
    }

    // GET: PizzaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(long id)
    {
        Pizza? pizzaToDelete = context.Pizzas.Find(id);

        // nullity check
        if (pizzaToDelete == null)
            return NotFound();

        context.Pizzas.Remove(pizzaToDelete);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
