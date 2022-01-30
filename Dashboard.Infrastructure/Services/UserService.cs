using Dashboard.Domain.Models;
using Dashboard.Infrastructure.Data;

namespace Dashboard.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task CreateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (await _userRepo.IsUserExist(user))
            {
                _userRepo.Update(user);
            }
            else
            {
                await _userRepo.CreateUser(user);
            }
            await _userRepo.SaveChanges();
        }

        public async Task CreateUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                await _userRepo.CreateUser(user);
            }
            await _userRepo.SaveChanges();
        }

        public void Update(User user)
        {
            _userRepo.Update(user);
        }
    }
}
