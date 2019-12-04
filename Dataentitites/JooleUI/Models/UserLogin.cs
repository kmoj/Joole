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
        [Display(Name ="Username or Email")]
        public string Login_Name { get; set; }


        //password propery for the object
        [Required(ErrorMessage = "This field is required")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string User_Password { get; set; }

        //Error message propery for the object
        public string LoginErrorMessage{ get; set; }

    }
}