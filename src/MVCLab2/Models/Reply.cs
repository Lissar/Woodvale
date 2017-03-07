using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models
{
    public class Reply
    {
        public int ReplyID { get; set; }

        [Required(ErrorMessage = "Please enter a reply")]
        public string Body { get; set; }
    }
}
