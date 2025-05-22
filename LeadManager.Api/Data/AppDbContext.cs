using Microsoft.EntityFrameworkCore;
using LeadManager.Api.Models;

namespace LeadManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Lead> Leads => Set<Lead>();
    }
}
