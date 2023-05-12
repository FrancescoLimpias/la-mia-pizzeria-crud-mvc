using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class DeveloperCommandModel
    {

        [Key]
        public int DeveloperCommandModelId { get; set; }

        public string Name { get; set; }
        public bool? Status { get; set; } = null;

        public Func<bool> Command { get; set; }

    }
}
