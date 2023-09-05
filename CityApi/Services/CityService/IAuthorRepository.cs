using System.Threading.Tasks;
using CityApi.Core.Entities;

namespace CityApi.Services.CityService
{
    public interface IAuthorRepository
    {
        Task<ServiceResponse<int>> Register(UserEntity user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
