using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class ExpenseModel
    {
        [Key]
        public Guid IdExpense { get; set; }
        public Guid ExpenseCategoryID { get; set; }
        public int Amount { get; set; }
        public Guid IdLocation { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
