using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class ExpenseCategoryModel
    {
        [Key]
        public Guid ExpenseCategoryID { get; set; }
        public string? Name { get; set; }
    }
}
