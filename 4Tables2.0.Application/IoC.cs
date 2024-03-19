using _4Tables2._0.Application.ProductDomain.Services;
using _4Tables2._0.Domain.ProductDomain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace _4Tables2._0.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
