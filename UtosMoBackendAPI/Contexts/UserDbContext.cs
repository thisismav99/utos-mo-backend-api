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
    }
}
