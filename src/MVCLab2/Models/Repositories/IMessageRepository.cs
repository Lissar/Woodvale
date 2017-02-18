using System.Collections.Generic;

namespace MVCLab2.Models.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetAllMessages();
    }
}
