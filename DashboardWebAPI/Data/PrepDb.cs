using Bogus;
using Dashboard.Domain.Models;
using Dashboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DashboardWebAPI.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"--> Could not run migrations: {ex.Message}");
            }

            if (context.Users.Any()) return;

            var testUsers = new Faker<User>()
                .RuleFor(u => u.UserId, f => f.UniqueIndex)
                .RuleFor(u => u.DateRegistration, f => f.Date.Recent(60, DateTime.Now.AddDays(-1)))
                .RuleFor(u => u.DateLastActivity, f => f.Date.Recent(30, DateTime.Now));

            var users = testUsers.Generate(0);

            context.AddRange(users);

            context.SaveChanges();
        }
    }
}
