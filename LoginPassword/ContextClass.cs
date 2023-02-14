using LoginPassword.Model;
using Microsoft.EntityFrameworkCore;

namespace LoginPassword
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Login> Logins { get; set; }

        public DbSet<LoginView> Loginviews { get; set; }

    }
}
