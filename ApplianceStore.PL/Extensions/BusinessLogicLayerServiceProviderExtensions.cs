using ApplianceStore.BLL.Interfaces;
using ApplianceStore.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApplianceStore.PL.Extensions
{
    public static class BusinessLogicLayerServiceProviderExtensions
    {
        public static void AddBusinessLogicLayer(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<ISupplyService, SupplyService>();
            services.AddScoped<IQueryService, QueryService>();
        }
    }
}
