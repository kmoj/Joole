using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JooleUI.Models
{
    public class LoginPage
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

        //Register for the object
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username")]
        public string RegisterUsername { get; set; }

        //Email property for the object
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email")]
        public string RegisterEmail { get; set; }


        //password propery for the object
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string RegisterPassword { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please Image file to upload.")]
        public HttpPostedFileBase RegisterUserImage { get; set; }

    }
}