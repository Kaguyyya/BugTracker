using BugTrackerWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }
       public DbSet<Ticket> Tickets { get; set; }
       public DbSet<Account>Accounts { get; set; }
    }
}
