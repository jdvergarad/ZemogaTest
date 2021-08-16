using System.Threading.Tasks;
using ZemogaTest.Services.Dtos;

namespace ZemogaTest.Services.Services
{
    public interface IUserService
    {
        Task<ApiResponse> CreateUser(AddNewUserRequest request);
        ApiResponse Login(LoginRequest request);
    }
}
