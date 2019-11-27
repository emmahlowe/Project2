using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Models
{
    public class Major
    {
        //[Table("Major")]
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Major ID is required.")]
        public int Major_ID { get; set; }


        [Display(Name = "Major Description")]
        [Required(ErrorMessage = "Major description is required.")]
        [StringLength(25, ErrorMessage = "Major desc. can't exceed 25 characters", MinimumLength = 1)]
        public string Major_Desc { get; set; }



    }
}