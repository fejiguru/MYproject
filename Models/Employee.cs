using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalureProject2.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Employee Name")]
        public  string Name { get; set;}
        [Required]
        [MaxLength(50)]
        [Display(Name = "Employee Department")]
        public  string Department { get; set; }


        [Required(ErrorMessage = "Exceed  limit is required"), Range(1, 50000)]
   
        [Display(Name = "Amount Requested")]
        public decimal Amount { get; set; }
        [Required]
       
        [Display(Name = "Request Date")]
        public DateTime Date { get; set; }

    }
}
