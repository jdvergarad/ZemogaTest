using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZemogaTest.Domain.Models;
using ZemogaTest.Repository.Repository;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;
        private IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateUser(AddNewUserRequest request)
        {
            ApiResponse response = new ApiResponse();
            var domainUser = _mapper.Map<User>(request);
            domainUser.Id = Guid.NewGuid();

            var userInDb = _repository.GetAll().Result.FirstOrDefault(user => user.UserName == request.UserName);

            if(userInDb != null)
            {
                return new ErrorResponse { Mensaje = $"User: '{request.UserName}' already exists in Database" };
            }

            await _repository.Create(domainUser);
            return _mapper.Map<AddNewUserResponse>(domainUser);
        }
    }
}
