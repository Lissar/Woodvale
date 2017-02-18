using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models.Repositories
{
    public class FakeMemberRepository : IMemberRepository
    {
        List<Member> members = new List<Member>();

        public FakeMemberRepository()
        {
            Member member = new Member { UserName = "member1", DisplayName = "Bob", Email = "bob@woodvale.com" };
            members.Add(member);
            member = new Member { UserName = "member2", DisplayName = "Joan", Email = "joan@woodvale.com" };
            members.Add(member);
            member = new Member { UserName = "member3", DisplayName = "Lou", Email = "lou@woodvale.com" };
            members.Add(member);
        }
        public IEnumerable<Member> GetAllMembers()
        {
            return members;
        }
    }
}