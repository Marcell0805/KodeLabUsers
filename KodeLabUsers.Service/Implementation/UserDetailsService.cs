using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KodeLabUsers.Domain.Entities;
using KodeLabUsers.Persistence;
using KodeLabUsers.Service.Contract;
using Microsoft.EntityFrameworkCore;

namespace KodeLabUsers.Service.Implementation
{
    public class UserDetailsService:IUserDetailsService
    {
        private readonly IGenericRepo<UserDetails> _repository;
        private readonly DbSet<UserDetails> _entity;
        public UserDetailsService(IGenericRepo<UserDetails> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _entity = context.Set<UserDetails>();
        }

        public void AddUser(UserDetails UserDetailsValues)
        {
            if (_entity != null)
            {
                _repository.Insert(UserDetailsValues);
                _repository.SaveChanges();
            }
        }

        public Task DeleteUser(int UserDetailsId)
        {
            throw new NotImplementedException();
        }
        //This method is responsible for reading the JSON file and returning the results
        public async Task<IEnumerable<UserDetails>> GetAll()
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

        public Task<IEnumerable<UserDetails>> GetByCriteria(object a)
        {
            throw new NotImplementedException();
        }
    }
}
