using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a comment")]
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member User { get; set; }
        [Required(ErrorMessage = "Please enter a topic")]
        public string Topic { get; set; }
        private List<Reply> replies = new List<Reply>();
        public List<Reply> MessageReplies { get { return replies; } }
    }
}
