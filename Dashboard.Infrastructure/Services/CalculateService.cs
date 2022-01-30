using Dashboard.Domain.Models;
using Dashboard.Infrastructure.Data;

namespace Dashboard.Infrastructure.Services
{
    public class CalculateService : ICalculateService
    {
        private readonly IUserRepo _userRepo;

        public CalculateService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<double> GetRollingRetentionKDay(int k)
        {
            var usersComeBackAfterMoreThanKDays = 0;
            var usersRegisteredLessThanKDaysAgo = 0;
            var userModels = await _userRepo.GetAllUsers();

            foreach (var user in userModels)
            {
                if (user.DateRegistration > user.DateLastActivity)
                {
                    continue;
                }
                if((user.DateLastActivity.Day - user.DateRegistration.Day) >= k) usersComeBackAfterMoreThanKDays++;
                if(user.DateRegistration.Day <= DateTime.Today.AddDays(-k).Day) usersRegisteredLessThanKDaysAgo++;
            }
            if (usersRegisteredLessThanKDaysAgo == 0) return 0;
            return Math.Round(100 * (double)(usersComeBackAfterMoreThanKDays) / (usersRegisteredLessThanKDaysAgo), 1);
        }

        public async Task<IEnumerable<UserLifeModel>> GetUsersLifeModels()
        {
            var userLifeModels = new List<UserLifeModel>();
            var userModels = await _userRepo.GetAllUsers();
            foreach (var user in userModels)
            {
                if (user.DateRegistration > user.DateLastActivity)
                {
                    continue;
                }
                userLifeModels.Add(new UserLifeModel()
                {
                    UserId = user.Id,
                    LifeDays = (user.DateLastActivity - user.DateRegistration).Days
                });
            }
            return userLifeModels;
        }
    }
}
