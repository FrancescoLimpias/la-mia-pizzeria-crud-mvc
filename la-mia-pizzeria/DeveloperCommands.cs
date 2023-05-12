using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static
{
    public static class DeveloperCommands
    {

        // Developer Commands
        public static List<DeveloperCommandModel> list = new()
        {
            new()
            {
                Name = "Seed Categories",
                Command = () =>
                {
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
