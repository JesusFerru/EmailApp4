using Microsoft.EntityFrameworkCore;

namespace EmailApp4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<DataEmail>? DataEmails { get; set; }
        public DbSet<EmailTemplate>? Templates { get; set; }
    }
}
