using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models
{
    public class Expense
    {   [Key]
        public int Id { get; set; }

        [DisplayName("Expense Type")]
        [Required]
        public string ExpenseType { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Number Must be Greater than Zero")]
        public int Amount { get; set; }
    }
}
