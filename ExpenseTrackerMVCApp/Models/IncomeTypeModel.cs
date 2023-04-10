using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class IncomeTypeModel
    {
        [Key]
        public Guid IncomeTypeID { get; set; }
        [Required(ErrorMessage = "This field is mandatory.")]
        public string? Name { get; set; }
    }
}
