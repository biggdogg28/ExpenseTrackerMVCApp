using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class TotalModel
    {
        [Key]
        public Guid IdTotals { get; set; }
        public decimal TotalExpenses { get; set; }
        public decimal TotalIncome { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
