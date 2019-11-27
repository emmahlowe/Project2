using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BootStrapProjectOne.Models
{
    public class FAQ
    {
        [Key]
        public int STUD_FAQ_ID { get; set; }

        public int Q_ID { get; set; }
    }
}