using Microsoft.EntityFrameworkCore;
using TechnicalAssignment.Api.Data.Entities;

namespace TechnicalAssignment.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarMake> CarMakes { get; set; }

    }
}
