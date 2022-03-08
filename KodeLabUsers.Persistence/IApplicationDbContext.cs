using System.Threading.Tasks;

namespace KodeLabUsers.Persistence
{
    public interface IApplicationDbContext
    {
        //DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync();
    }
}