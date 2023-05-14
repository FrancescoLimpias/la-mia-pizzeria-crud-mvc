using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Seeders
{
    public class PizzaSeeder : Seeder<Pizza>
    {

        public PizzaSeeder() : base(new()
        {
            new ("Margherita", "La classica margherita", 8, true),
            new ("Quattro Formaggi", "Gorgonzola, bufala, ricotta e cacio", 9.5),
            new ("Prataiola", "Solo verdure e ingredienti bio!", 10.5),
            new ("Spicy Salmon", "Ispirata al famoso sushi roll", 11),
            new ("Capricciosa", "Il nostro cavallo di battaglia", 9.5),
            new ("Diavola", "La mia preferita :p", 9, true),
            new ("Vienna", null, 9, false),
        })
        { }

        readonly Random random = new Random();
        public override Pizza GenerateElementFromRawData(Pizza data)
        {
            // Attach category if available
            var categories = context.Categories.ToList();
            if (categories.Count() > 0)
            {
                int randomCategoryId = random.Next(categories.Count() - 1);
                data.CategoryId = categories[randomCategoryId].CategoryId;
            }

            return data;
        }

        public override DbSet<Pizza> GetDbSet(PizzeriaContext context)
        {
            return context.Pizzas;
        }
    }
}
