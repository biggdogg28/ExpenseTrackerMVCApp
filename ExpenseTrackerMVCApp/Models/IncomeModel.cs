using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerMVCApp.Models
{
    public class IncomeModel
    {
        [Key]
        public Guid IdIncome { get; set; }
        public string? Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "This field is mandatory.")]
        public decimal Amount { get; set; }
        public Guid IncomeTypeID { get; set; }
        public string? Notes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
