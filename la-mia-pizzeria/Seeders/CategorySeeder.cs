using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Seeders
{
    public class CategorySeeder : Seeder<string, Category>
    {
        public CategorySeeder() : base(new()
            {
                "Normale",
                "Pala",
                "Maxi",
                "Metro",
                "Vegana"
            })
        { }

        public override DbSet<Category> GetDbSet(PizzeriaContext context)
        {
            return context.Categories;
        }

        public override Category GenerateElementFromRawData(string name)
        {
            return new()
            {
                Name = name,
            };
        }
    }
}
