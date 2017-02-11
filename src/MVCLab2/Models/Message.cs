using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models
{
    public class Message
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string Topic { get; set; }
    }
}
