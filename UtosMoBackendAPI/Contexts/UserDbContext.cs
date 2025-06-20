using Microsoft.EntityFrameworkCore;
using UtosMoBackendAPI.Models.UserModels;

namespace UtosMoBackendAPI.Contexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<UserModel> User { get; set; }

        public DbSet<EducationModel> Education { get; set; }

        public DbSet<AddressModel> Address { get; set; }

        public DbSet<HonorModel> Honor { get; set; }

        public DbSet<SalaryModel> Salary { get; set; }

        public DbSet<WorkModel> Work { get; set; }

        public DbSet<IndustryModel> Industry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkModel>()
                .HasMany(w => w.Industries)
                .WithMany(i => i.Works)
                .UsingEntity<Dictionary<string, object>>(
                    "WorkIndustries",
                    x => x.HasOne<IndustryModel>().WithMany().HasForeignKey("IndustryID"),
                    x => x.HasOne<WorkModel>().WithMany().HasForeignKey("WorkID"),
                    x =>
                    {
                        x.HasKey("WorkID", "IndustryID");
                        x.ToTable("WorkIndustries");
                    }
                );
        }
    }
}
