using System.Collections.Generic;
using System.Threading.Tasks;
using KodeLabUsers.Domain.Entities;

namespace KodeLabUsers.Service.Contract
{
    public interface IUserDetailsService
    {
        Task<IEnumerable<UserDetails>> GetAll();
        Task<IEnumerable<UserDetails>> GetByCriteria(object a);
        void AddUser(UserDetails userDetails);
        Task DeleteUser(int userId);
    }
}