using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class LocationModel
    {
        [Key]
        public Guid IdLocation { get; set; }
        public string Name { get; set; }
    }
}
