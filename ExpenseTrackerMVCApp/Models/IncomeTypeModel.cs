using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerMVCApp.Models
{
    public class IncomeTypeModel
    {
        [Key]
        public Guid IncomeTypeID { get; set; }
        public string Name { get; set; }
    }
}
