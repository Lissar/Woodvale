using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MVCLab2.Models.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext context;

        public MessageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return context.Messages.Include(m => m.User).Include(m => m.MessageReplies);
        }

        public int Update(Message message)
        {
            if (message.MessageID == 0)
                context.Messages.Add(message);
            else
                context.Messages.Update(message);

            return context.SaveChanges();
        }
    }
}
