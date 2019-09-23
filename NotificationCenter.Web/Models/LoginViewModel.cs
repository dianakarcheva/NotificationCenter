using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace NotificationCenter.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [RegularExpression("^[a-z0-9_-]{5,16}$")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}