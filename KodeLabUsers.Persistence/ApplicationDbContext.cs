using System.Threading.Tasks;
using KodeLabUsers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KodeLabUsers.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        // This constructor is used of runit testing
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public DbSet<UserDetails> Details { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address{ AddressId= 1, City= "Pmb", Country= "ZA", LineOne= "Home", LineTwo = " Street",PostCode = "3201"},
            new Address { AddressId = 2, City = "Pmb", Country = "ZA", LineOne = "Home2", LineTwo = " Street2", PostCode = "3201" },
            new Address { AddressId = 3, City = "Pmb", Country = "ZA", LineOne = "Home3", LineTwo = " Street3", PostCode = "3201" }
                );
            modelBuilder.Entity<UserDetails>().HasData(
                new UserDetails { CustId = 1,Firstname = "Marcell",Lastname = "Smith",DateOfBirth = "1996",Age = 25,Email = "marcellvanniekerk@gmail.com",IdNumber = "12345678910", AddressId=1},
                new UserDetails { CustId = 2, Firstname = "John", Lastname = "Snow", DateOfBirth = "1980", Age = 25, Email = "johnnyA@gmail.com", IdNumber = "12345678911", AddressId = 2 },
                new UserDetails { CustId = 3, Firstname = "Kevin", Lastname = "Eleven", DateOfBirth = "1997", Age = 25, Email = "kevinSnow@gmail.com", IdNumber = "12345678912", AddressId = 3 }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder
                    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=UserStorageDB");
        }
    }
}