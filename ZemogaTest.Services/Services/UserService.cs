using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

            if (userInDb != null)
            {
                return new ErrorResponse { Mensaje = $"User: '{request.UserName}' already exists in Database" };
            }

            await _repository.Create(domainUser);
            return _mapper.Map<AddNewUserResponse>(domainUser);
        }

        public ApiResponse Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse();
            var user = AuthenticateUser(request.Username, request.Password);

            if (user == null)
            {
                return new ErrorResponse { Mensaje = $"User: '{request.Username}' does not exist in Database" };
            }

            var token = GenerateJSONToken(user);

            response.Token = token;

            return response;
        }


        private User AuthenticateUser(string username, string password)
        {
            return _repository.GetAll().Result.FirstOrDefault(user => user.UserName == username
                                                                    && user.Password == password);
        }
        private string GenerateJSONToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ZemogaTest_Secret_Key"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
            };

            var token = new JwtSecurityToken
            (
                issuer: "Zemoga",
                audience: "Zemoga",
                claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
            );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }
    }
}
