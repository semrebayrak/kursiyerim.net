
using System.ComponentModel.DataAnnotations;

using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;

namespace Test.Models
{


    public class LoginModel


    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string password { get; set; }


    }
}