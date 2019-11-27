using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Models
{
    //[Table("Question")]
    public class Question
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Question_ID { get; set; }

        [Required(ErrorMessage = "Please enter a question.")]
        [Display(Name = "Question")]
        [StringLength(120, ErrorMessage = "Question can't exceed 120 characters and must be at least 1 character", MinimumLength = 1)]
        public string sQuestion { get; set; }
    }
}