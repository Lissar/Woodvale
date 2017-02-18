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
            return context.Messages.Include(m => m.User);
        }
    }
}
