using la_mia_pizzeria_static;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers;
public class PizzaController : Controller
{

    // GET: PizzaController
    public ActionResult Index()
    {
        return View(Pizzas.list);
    }

    // GET: PizzaController/Details/5
    public ActionResult Details(int id)
    {
        return View(Pizzas.list[id]);
    }

    // GET: PizzaController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PizzaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Pizza data)
    {

        if (!ModelState.IsValid)
        {
            return View("Create", data);
        }

        try
        {
            // attempt to create a new pizza
            Pizza newPizza = new();
            newPizza.name = data.name;
            newPizza.description = data.description;
            newPizza.price = data.price;

            Pizzas.list.Add(newPizza);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: PizzaController/Edit/5
    public ActionResult Edit(int id)
    {
        Pizza searchedPizza = Pizzas.list[id];

        if (searchedPizza == null)
            return NotFound();

        return View(searchedPizza);
    }

    // POST: PizzaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Pizza data)
    {

        if (!ModelState.IsValid)
        {
            return View("Edit", data);
        }

        try
        {
            // attempt to create a new pizza
            Pizza pizzaToEdit = Pizzas.list[id];
            pizzaToEdit.name = data.name;
            pizzaToEdit.description = data.description;
            pizzaToEdit.price = data.price;

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return NotFound();
        }
    }

    // GET: PizzaController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: PizzaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
