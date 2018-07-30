using System.Threading.Tasks;
using YoAdopto.API.Models;

namespace YoAdopto.API.Contracts
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username, string email);
    }
}