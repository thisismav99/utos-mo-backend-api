using Microsoft.EntityFrameworkCore;
using UtosMoBackendAPI.Models.ReviewModels;

namespace UtosMoBackendAPI.Contexts
{
    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<ReviewModel> Review { get; set; }
    }
}
