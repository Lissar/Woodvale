using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models.Repositories
{
    public class FakeMessageRepository : IMessageRepository
    {
        public IEnumerable<Message> Messages => new List<Message>
        {
            new Message {UserName = "member1", Title = "Hello!", Body = "A new message.", Date = DateTime.Now, Topic = "Introduction"},
            new Message {UserName = "member2", Title = "Goodbye!", Body = "Another message.", Date = DateTime.Now, Topic = "Leaving"},
            new Message {UserName = "member3", Title = "Meh", Body = "More messages.", Date = DateTime.Now, Topic = "Boredom"},
        };

        public List<Message> GetMessages()
        {
            var messages = new List<Message>();
            messages.Add(new Message { UserName = "member1", Title = "Hello!", Body = "A new message.", Date = DateTime.Now, Topic = "Introduction" });
            messages.Add(new Message { UserName = "member2", Title = "Goodbye!", Body = "Another message.", Date = DateTime.Now, Topic = "Leaving" });
            messages.Add(new Message { UserName = "member3", Title = "Meh", Body = "More messages.", Date = DateTime.Now, Topic = "Boredom" });
            return messages;
        }
    }
}