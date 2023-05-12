using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Seeders
{
    public static class CategorySeeder
    {

        static List<string> categoriesNames = new List<string>()
        {
            "Normale",
            "Pala",
            "Maxi",
            "Metro",
            "Vegana"
        };

        public static void Run()
        {

            using PizzeriaContext context = new PizzeriaContext();
            {
                foreach (var categoryName in categoriesNames)
                {
                    Category newCategory = new() { Name = categoryName };
                    context.Categories.Add(newCategory);
                }
                context.SaveChanges();
            }

        }
    }
}
