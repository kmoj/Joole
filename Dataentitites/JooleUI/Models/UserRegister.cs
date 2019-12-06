using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JooleUI.Models
{
    public class UserRegister
    {
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase userImgUrl { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email.")]
        public string userEmail { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at lease {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string userPassword { get; set; }

        [Required]
        [Compare("userPassword", ErrorMessage = "The password you entered do not match.")]
        [Display(Name = "Confirm Password")]
        public string confirmPassword { get; set; }

        public string RegisterErrorMessage { get; set; }

    }
}