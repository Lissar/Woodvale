using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MVCLab2.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            

            if (!context.Messages.Any())
            {
               
                Member member = new Member { UserName = "member1", DisplayName = "Bob", Email = "bob@woodvale.com" };
                context.Members.Add(member);
                Message message = new Message { Title = "Hello!", Body = "A new message.", Date = DateTime.Now, Topic = "Introduction" };
                message.User = member;
                context.Messages.Add(message);

                member = new Member { UserName = "member2", DisplayName = "Joan", Email = "joan@woodvale.com" };
                context.Members.Add(member);
                message = new Message { Title = "Goodbye!", Body = "Another message.", Date = DateTime.Now, Topic = "Leaving" };
                message.User = member;
                context.Messages.Add(message);

                member = new Member { UserName = "member3", DisplayName = "Lou", Email = "lou@woodvale.com" };
                context.Members.Add(member);
                message = new Message { Title = "Meh", Body = "More messages.", Date = DateTime.Now, Topic = "Boredom" };
                message.User = member;
                context.Messages.Add(message);

                message = new Message { Title = "Double Meh", Body = "I had to write even more because boredom.", Date = DateTime.Now, Topic = "Boredom" };
                message.User = member;
                context.Messages.Add(message);

                context.SaveChanges();

            }
        }
    }
}
