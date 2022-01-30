using Dashboard.Domain.Models;

namespace Dashboard.Infrastructure.Data
{
    public interface IUserRepo
    {
        Task<bool> SaveChanges();
        Task CreateUser(User user);
        Task<IEnumerable<User>> GetAllUsers();
        void Update(User user);
        Task<bool> IsUserExist(User user);
    }
}
