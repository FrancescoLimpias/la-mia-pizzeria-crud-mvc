using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class DeveloperController : Controller
    {

        // GET: DeveloperController
        public ActionResult Index()
        {
            return View(DeveloperCommands.list);
        }

        // POST: DeveloperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Execute([FromForm] int index)
        {
            try
            {
                //Reset idle states
                DeveloperCommands.list = DeveloperCommands.list.Select(command =>
                {
                    command.Status = null;
                    return command;
                }).ToList();

                //Execute command
                DeveloperCommandModel DVM = DeveloperCommands.list[index];
                DVM.Status = DVM.Command();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
