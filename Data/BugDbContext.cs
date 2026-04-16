using Microsoft.EntityFrameworkCore;
using BugTrackingApiDotNet.Models;

namespace BugTrackingApiDotNet.Data
{
    public class BugDbContext : DbContext
    {
        public BugDbContext(DbContextOptions<BugDbContext> options) : base(options)
        {
        }

        public DbSet<Bug> Bugs => Set<Bug>();
    }
}