using Dashboard.Domain.Models;

namespace Dashboard.Infrastructure.Services
{
    public interface IUserService
    {
        Task CreateUsers(IEnumerable<User> users);
        Task CreateUser(User user);
        void Update(User user);
    }
}
