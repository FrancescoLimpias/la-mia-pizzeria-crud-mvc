using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Ingredient
    {

        [Key]
        public long IngredientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Symbol { get; set; }

        [Required]
        public bool Allergen { get; set; }

        public List<Pizza> Pizzas { get; set; }

        public Ingredient() { }

    }
}
