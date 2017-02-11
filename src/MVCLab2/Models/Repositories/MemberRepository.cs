using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCLab2.Models.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public IEnumerable<Member> Members => new List<Member>
        {
            new Member {UserName = "member1", DisplayName = "Bob", Email = "bob@woodvale.com" },
            new Member {UserName = "member2", DisplayName = "Joan", Email = "joan@woodvale.com" },
            new Member {UserName = "member3", DisplayName = "Lou", Email = "lou@woodvale.com" }
        };

        public List<Member> GetMembers()
        {
            var members = new List<Member>();
            members.Add(new Member { UserName = "member1", DisplayName = "Bob", Email = "bob@woodvale.com" });
            members.Add(new Member { UserName = "member2", DisplayName = "Joan", Email = "joan@woodvale.com" });
            members.Add(new Member { UserName = "member3", DisplayName = "Lou", Email = "lou@woodvale.com" });
            return members;
        }
    }
}
