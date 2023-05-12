using la_mia_pizzeria_static.Models;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaPayload
    {

        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }

    }
}
