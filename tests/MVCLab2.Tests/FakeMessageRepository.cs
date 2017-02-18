using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models.Repositories
{
    public class FakeMessageRepository : IMessageRepository
    {
        List<Message> messages = new List<Message>();

        public FakeMessageRepository()
        {
            Message message = new Message { Title = "Hello!", Body = "A new message.", Date = DateTime.Now, Topic = "Introduction" };
            message.User = new Member { UserName = "member1" };
            messages.Add(message);

            message = new Message { Title = "Goodbye!", Body = "Another message.", Date = DateTime.Now, Topic = "Leaving" };
            message.User = new Member { UserName = "member2" };
            messages.Add(message);

            message = new Message { Title = "Meh", Body = "More messages.", Date = DateTime.Now, Topic = "Boredom" };
            message.User = new Member { UserName = "member3" };
            messages.Add(message);
        }

        public IEnumerable<Message>GetAllMessages()
        {

            return messages;
        }
    }
}