using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SummitSchool.Models;

namespace SummitSchool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SchoolStudent> SchoolStudent { get; set; }

        public DbSet<SummitSchool.Models.Movie> Movie { get; set; }
    }
}

