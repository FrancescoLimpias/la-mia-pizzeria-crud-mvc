using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Seeders
{
    public class IngredientSeeder : Seeder<ValueTuple<string, string, bool>, Ingredient>
    {

        public IngredientSeeder() : base(new()
            {
                ("Pomodoro", "🍅", false),
                ("Mozzarella", "🧀", true),
                ("Funghi", "🍄", false),
                ("Prosciutto", "🍖", true),
                ("Salame", "🍗", true),
                ("Peperoni", "🌶️", false),
                ("Cipolla", "🧅", false),
                ("Olive", "🫒", false),
                ("Salsiccia", "🌭", true),
                ("Carciofi", "🌿", false),
                ("Olive nere", "🍸", false),
                ("Basilico", "🌿", false),
                ("Origano", "🍃", false),
                ("Pepperoncino", "🌶️", false),
                ("Peperoncini jalapeños", "🌶️", false),
                ("Peperoncini habanero", "🌶️", false),
                ("Ananas", "🍍", false),
                ("Gamberetti", "🍤", true),
                ("Tonno", "🐟", true),
                ("Melanzane", "🍆", false),
                ("Zucchine", "🥒", false),
                ("Peperoni verdi", "🟢", false),
                ("Mais", "🌽", false),
                ("Patate", "🥔", false),
            })
        { }

        public override DbSet<Ingredient> GetDbSet(PizzeriaContext context)
        {
            return context.Ingredients;
        }

        public override Ingredient GenerateElementFromRawData(ValueTuple<string, string, bool> rawData)
        {
            return new()
            {
                Name = rawData.Item1,
                Symbol = rawData.Item2,
                Allergen = rawData.Item3,
            };
        }
    }
}
