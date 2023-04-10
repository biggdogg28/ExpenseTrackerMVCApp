using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class ExpenseCategoryModel
    {
        [Key]
        public Guid ExpenseCategoryID { get; set; }
        [Required(ErrorMessage = "This field is mandatory.")]
        public string? Name { get; set; }
    }
}
