using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;//This namespace contains attributes to be set for validations

//MVC uses Data Anotations to set the validations for UR data. 
namespace SampleMvcApp.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Name must be entered")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email address is a must")]
        [EmailAddress(ErrorMessage ="Invalid Email format")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Age must be set")]
        [Range(18,45,ErrorMessage = "Age should be b/w 18 to 45")]
        public int Age { get; set; }
    }
}