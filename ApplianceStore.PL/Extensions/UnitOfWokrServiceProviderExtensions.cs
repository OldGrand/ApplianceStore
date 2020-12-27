using ApplianceStore.DAL.Interfaces;
using ApplianceStore.DAL.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ApplianceStore.PL.Extensions
{
    public static class UnitOfWokrServiceProviderExtensions
    {
        public static void AddUnitOfWorkAndRepository(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
