using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace avsserv.Models
{
    public class Employees
    {
       [Key]
        public int ID { get; set; }
        [Required]
        public string EmpNo { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public DateTime DateHired { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Complexion { get; set; }
        public byte? Image { get; set; }
        public string Position { get; set; }
        public string SSS { get; set; }
        public string TIN { get; set; }
        public string Pagibig { get; set; }
        public string Philhealth { get; set; }
        public string Passport { get; set; }
    }
}
