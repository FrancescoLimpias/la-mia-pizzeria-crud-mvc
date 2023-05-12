using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class DeveloperCommandModel
    {

        [Key]
        public Guid DeveloperCommandModelGuid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }
        public bool? Status { get; set; } = null;

        public Func<bool> Execution { get; set; }

        public DeveloperCommandModel(string Name, Func<bool> Execution)
        {
            this.Name = Name;
            this.Execution = Execution;
        }

        public bool? Execute()
        {
            try
            {
                Status = Execution();
            }
            catch (Exception ex)
            {
                Status = false;
            }
            return Status;
        }

        public void SetIdle()
        {
            Status = null;
        }

    }
}
