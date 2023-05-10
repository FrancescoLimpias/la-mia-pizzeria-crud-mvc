using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Categoria
    {

        [Key]
        public string Name { get; set; }

        public List<Pizza> Pizzas { get; set; }

        Categoria() { }

    }
}
