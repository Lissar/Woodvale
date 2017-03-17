using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MVCLab2.Models
{
    public class SeedData
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            UserManager<User> userManager = app.ApplicationServices.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Messages.Any())
            {


                User member = await userManager.FindByNameAsync("member1");
                if (member == null)
                {
                    member = new User { UserName = "member1", DisplayName = "Bob", Email = "bob@woodvale.com" };
                    IdentityResult result = await userManager.CreateAsync(member, "Password1$");
                }                                   

                Message message = new Message { Title = "Hello!", Body = "A new message.", Date = DateTime.Now, Topic = "Introduction", User = member };
                context.Messages.Add(message);

                member = await userManager.FindByNameAsync("member2");
                if (member == null)
                {
                    member = new User { UserName = "member2", DisplayName = "Joan", Email = "joan@woodvale.com" };
                    IdentityResult result = await userManager.CreateAsync(member, "Password1$");
                }

                message = new Message { Title = "Goodbye!", Body = "Another message.", Date = DateTime.Now, Topic = "Leaving", User = member };
                context.Messages.Add(message);

                member = await userManager.FindByNameAsync("member3");
                if (member == null)
                {
                    member = new User { UserName = "member3", DisplayName = "Lou", Email = "lou@woodvale.com" };
                    IdentityResult result = await userManager.CreateAsync(member, "Password1$");
                }

                message = new Message { Title = "Meh", Body = "More messages.", Date = DateTime.Now, Topic = "Boredom", User = member };
                context.Messages.Add(message);

                message = new Message { Title = "Double Meh", Body = "I had to write even more because boredom.", Date = DateTime.Now, Topic = "Boredom", User = member };
                context.Messages.Add(message);

                context.SaveChanges();

            }
        }
    }
}
