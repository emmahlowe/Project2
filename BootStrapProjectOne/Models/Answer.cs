using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootStrapProjectOne.Models
{
    [Table("Answer")]
    public class Answer
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Answer_ID { get; set; }

        [Required(ErrorMessage = "Please enter an answer.")]
        [Display(Name = "Answer")]
        [StringLength(900, ErrorMessage = "Answer must be at least 1 character", MinimumLength = 1)]
        public string sAnswer { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        public int Question_ID { get; set; }

    }
}