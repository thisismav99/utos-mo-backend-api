using Microsoft.EntityFrameworkCore;
using UtosMoBackendAPI.Models.BookingModels;

namespace UtosMoBackendAPI.Contexts
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<BookingModel> Booking { get; set; }

        public DbSet<TransactionModel> Transaction { get; set; }
    }
}
