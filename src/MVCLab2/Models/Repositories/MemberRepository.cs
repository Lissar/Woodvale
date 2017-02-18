using System.Collections.Generic;

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
    }
}
