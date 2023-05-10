using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static
{
    public static class PizzasSeeder
    {

        public static List<Pizza> list = new List<Pizza>()
        {
            new Pizza("Margherita", "La classica margherita", 8.50, true),
            new Pizza("Capricciosa", "Il nostro cavallo di battaglia", 8.50),
            new Pizza("Diavola", "La mia preferita :p", 8.50, true),
        };

    }
}
