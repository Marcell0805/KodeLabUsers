using System.Threading.Tasks;
using KodeLabUsers.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KodeLabUsers.Persistence
{
    public interface IApplicationDbContext
    { 
        DbSet<UserDetails> Details { get; set; }
        DbSet<Address> Addresses { get; set; }
        Task<int> SaveChangesAsync();
    }
}