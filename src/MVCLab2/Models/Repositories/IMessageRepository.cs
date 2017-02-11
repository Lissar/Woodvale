using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> Messages { get; }

        List<Message> GetMessages();
    }
}
