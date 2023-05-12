using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Seeders;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static
{
    public static class DeveloperCommands
    {

        // Developer Commands
        public static List<DeveloperCommandModel> list = new()
        {

            /* CATEGORIES */
            //clear
            new()
            {
                Name = "Clear Categories",
                Command = () =>
                {
                    using(PizzeriaContext context = new PizzeriaContext())
                    {
                        context.Categories.ExecuteDelete();
                        context.SaveChanges();
                    }
                    return true;
                },
            },

            //seed      
            new()
            {
                Name = "Seed Categories",
                Command = () =>
                {
                    CategorySeeder.Run();
                    return true;
                },
            },

            new()
            {
                Name = "Seed Pizzas",
                Command = () =>
                {
                    return false;
                }
            }
        };
    }
}
