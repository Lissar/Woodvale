using Microsoft.EntityFrameworkCore;

namespace MVCLab2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Member> Members { get; set; }
    }
}
