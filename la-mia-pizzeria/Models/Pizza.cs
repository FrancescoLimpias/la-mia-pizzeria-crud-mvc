using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {

        [Key]
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string name { get; set; }

        [StringLength(100)]
        [LongDescriptionValidation]
        public string? description { get; set; }

        private bool _thereIsAnImage { get; set; }

        public string? ImagePath
        {
            get
            {
                if (_thereIsAnImage)
                    return "../../img/pizza" + name.ToLower() + ".jpg";
                else
                    return null;
            }
        }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public double price { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public Pizza()
        {
            _thereIsAnImage = false;
        }

        public Pizza(string name, string description, double price, bool thereIsAnImage = false)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            _thereIsAnImage = thereIsAnImage;
        }
    }
}
