using System.Collections.Generic;
using System.Linq;

namespace MVCLab2.Models.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private ApplicationDbContext context;

        public MemberRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return context.Members;
        }

        public Member GetMemberByUserName(string username)
        {
            return context.Members.First(m => m.UserName == username);
        }
    }
}
