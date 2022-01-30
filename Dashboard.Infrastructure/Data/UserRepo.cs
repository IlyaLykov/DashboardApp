using Dashboard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Infrastructure.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            await _context.Users.AddAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> IsUserExist(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            return await _context.Users.Where(u => u.UserId == user.UserId).FirstOrDefaultAsync() != null;
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void Update(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            var model = _context.Users.Where(u => u.UserId == user.UserId).First();
            model.DateRegistration = user.DateRegistration;
            model.DateLastActivity = user.DateLastActivity;
        }
    }
}
