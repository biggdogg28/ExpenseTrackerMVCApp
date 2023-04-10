using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class LocationModel
    {
        [Key]
        public Guid IdLocation { get; set; }
        [Required(ErrorMessage = "This field is mandatory.")]
        public string? Name { get; set; }
    }
}
