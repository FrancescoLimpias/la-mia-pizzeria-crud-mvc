using la_mia_pizzeria_static.Models;
using la_mia_pizzeria_static.Models.Utility;
using la_mia_pizzeria_static.Seeders;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static
{
    public static class DeveloperCommands
    {

        static PizzeriaContext context = new PizzeriaContext();

        // Developer Commands
        public static List<DeveloperCommandsGroup> groups = new()
        {
            /* CATEGORIES */
            new("Categories", new()
            {
                    
                //clear
                new(
                    "Clear categories",
                    () =>
                    {
                        context.Categories.ExecuteDelete();
                        context.SaveChanges();
                        return true;
                    }),

                //seed      
                new(
                    "Seed categories",
                    () =>
                    {
                        new CategorySeeder().Run();
                        return true;
                    }
                ),
            }),

            new("Pizzas", new()
            {

                //clear
                new(
                    "Clear pizzas",
                    () =>
                    {
                        context.Pizzas.ExecuteDelete();
                        context.SaveChanges();
                        return true;
                    }
                ),

                //seed      
                new(
                    "Seed pizzas",
                    () =>
                    {
                        new PizzaSeeder().Run();
                        return true;
                    }
                ),

            }),

        };
    }
}
