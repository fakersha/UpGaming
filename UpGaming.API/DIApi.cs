using UpGaming.API.Filters;

namespace UpGaming.API
{
    public static class DIApi
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add<ApiExceptionFilterAttribute>());

            services.AddLogging();

            return services;
        }
    }
}
