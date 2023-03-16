using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class SavingModel
    {
        [Key]
        public Guid IdSavings { get; set; }
        public string Name { get; set; }
        public Guid IdIncome { get; set; }
        public int Amount { get; set; }
    }
}
