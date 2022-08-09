using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;

namespace Api.Service.Services
{
    public class UserService : IUserService     // 1.   2.
    {
        private IRepository<UserEntity, int> _repository;         // 3.

        public UserService(IRepository<UserEntity, int> repository)  // 4. 
        {
            _repository = repository;
        }


        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntity> Put(UserEntity user)
        {
            return await _repository.UpdateAsync(user);
        }
    }
}
