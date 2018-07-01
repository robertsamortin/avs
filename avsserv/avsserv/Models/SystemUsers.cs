using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace avsserv.Models
{
    public class SystemUsers
    {
       [Key]
        public int ID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string AccessLevel { get; set; }
    }
}
