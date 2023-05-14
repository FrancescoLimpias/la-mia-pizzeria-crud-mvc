using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Category
    {

        [Key]
        public long CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Symbol { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public Category() { }

    }
}
