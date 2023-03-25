using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class IncomeModel
    {
        [Key]
        public Guid IdIncome { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public Guid IncomeTypeID { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
