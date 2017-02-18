using System.Collections.Generic;

namespace MVCLab2.Models.Repositories
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetAllMembers();
    }
}
