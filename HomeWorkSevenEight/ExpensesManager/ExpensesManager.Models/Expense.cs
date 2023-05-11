using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesManager.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Spent Money")]
        public double SpentMoney { get; set; }

        [Required]
        public string Comment { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        [NotMapped]
        public string CreatedDateTimeToRender { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; }

    }
}
