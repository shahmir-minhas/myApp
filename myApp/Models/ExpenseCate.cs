using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models
{
    public class ExpenseCate
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Expense Category")]
        public string ExpenseCategory { get; set; }

    }
}
