using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    public class DeveloperController : Controller
    {

        // GET: DeveloperController
        public ActionResult Index()
        {
            return View(DeveloperCommands.Groups);
        }

        // POST: DeveloperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Execute([FromForm] Guid guid)
        {
            try
            {
                DeveloperCommandModel? DVM = null;

                foreach (DeveloperCommandsGroup group in DeveloperCommands.Groups)
                {
                    //Reset idle states
                    group.SetCommandsStatusToIdle();

                    //Find command
                    DVM ??= group.GetDeveloperCommandModel(guid);

                }

                //Nullity check
                if (DVM == null)
                    throw new NullReferenceException("The requested command was not found");

                //Execute command
                DVM.Execute();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
