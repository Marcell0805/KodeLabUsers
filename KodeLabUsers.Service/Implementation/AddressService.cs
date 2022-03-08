using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KodeLabUsers.Domain.Entities;
using KodeLabUsers.Persistence;
using KodeLabUsers.Service.Contract;
using Microsoft.EntityFrameworkCore;

namespace KodeLabUsers.Service.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly IGenericRepo<Address> _repository;
        private readonly DbSet<Address> _entity;

        public AddressService(IGenericRepo<Address> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _entity = context.Set<Address>();
        }

        public void AddAddress(Address AddressValues)
        {
            if (_entity != null)
            {
                _repository.Insert(AddressValues);
                _repository.SaveChanges();
            }
        }

        public Task DeleteAddress(int AddressId)
        {
            throw new NotImplementedException();
        }

        //This method is responsible for reading the JSON file and returning the results
        public async Task<IEnumerable<Address>> GetAll()
        {
            try
            {

                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Task<IEnumerable<Address>> GetByCriteria(object a)
        {
            throw new NotImplementedException();
        }
    }

}