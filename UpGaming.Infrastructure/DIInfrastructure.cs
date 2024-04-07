using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using UpGaming.Application.Services;
using UpGaming.Domain.Repositories;
using UpGaming.Infrastructure.Implements.Repositories;
using UpGaming.Infrastructure.Implements.Services;
using UpGaming.Infrastructure.Models;

namespace UpGaming.Infrastructure
{
    public static class DIInfrastructure
    {
        public static void AddInsfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("UpGamingDb")!;
            var dbConnectionString = new DbConnectionString { ConnectionString = connectionString };

            services.AddSingleton(dbConnectionString);

            services.AddScoped<IScoresRepository, ScoresRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUpGamingScoreService, UpGamingScoreService>();
            services.AddScoped<IUpGamingUserService, UpGamingUserService>();
        }
    }
}
