using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JooleUI.Models
{
    public class UserLogin
    {

        //Login_Name property for the object
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Text)]
        [Display(Name ="Username")]
        public string Login_Name { get; set; }


        //password propery for the object
        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at lease {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string User_Password { get; set; }

        //Error message propery for the object
        public string LoginErrorMessage{ get; set; }

    }
}