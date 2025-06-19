using Microsoft.EntityFrameworkCore;
using UtosMoBackendAPI.Models.WorkModels;

namespace UtosMoBackendAPI.Contexts
{
    public class WorkDbContext : DbContext
    {
        public WorkDbContext(DbContextOptions<WorkDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }

        public DbSet<WorkModel> Work { get; set; }

        public DbSet<IndustryModel> Industry { get; set; }
    }
}
