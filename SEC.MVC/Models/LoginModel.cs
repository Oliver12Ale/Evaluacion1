using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEC.MVC.Models
{
    public class LoginModel
    {
        [Display(Name = "Login")]
        [Required]
        public string Usuario { get; set; }
        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}