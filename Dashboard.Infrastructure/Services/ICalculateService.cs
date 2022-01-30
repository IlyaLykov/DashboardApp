using Dashboard.Domain.Models;

namespace Dashboard.Infrastructure.Services
{
    public interface ICalculateService
    {
        Task<IEnumerable<UserLifeModel>> GetUsersLifeModels();
        Task<double> GetRollingRetentionKDay(int k);
    }
}
