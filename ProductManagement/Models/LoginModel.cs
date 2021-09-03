using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
