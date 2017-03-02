using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public Member User { get; set; }
        public string Topic { get; set; }
        private List<Reply> replies = new List<Reply>();
        public List<Reply> MessageReplies { get { return replies; } }
    }
}
