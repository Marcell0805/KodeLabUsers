using System.Collections.Generic;
using System.Threading.Tasks;
using KodeLabUsers.Domain.Entities;

namespace KodeLabUsers.Service.Contract
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAll();
        Task<IEnumerable<Address>> GetByCriteria(object a);
        void AddAddress(Address addressDetails);
        Task DeleteAddress(int addressId);
    }
}