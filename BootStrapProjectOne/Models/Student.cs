using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [HiddenInput(DisplayValue=false)] //auto incremented PK
        public int? StudID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [MaxLength(30)]
        public string fName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [MaxLength(30)]
        public string lName { get; set; }

        [Display(Name = "Major")]
        public int Major_ID { get; set; } //this will be a drop down
        
        //[Display(Name = "Headshot")]
        //public Image Picture { get; set; }

        [Required]
        [Display(Name = "I interned with...")]
        public string Company { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "I landed my internship by...")]
        public string Experience { get; set; }

        [Required]
        [Display(Name = "My internship was during the year of...")]
        public int Internship_Year { get; set; }

    }
}