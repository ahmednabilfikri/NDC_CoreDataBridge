using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NDC_Core_DataBridge.Interfaces;
using NDC_Core_DataBridge.Models.Context;
using NDC_Core_DataBridge.Repositories;

namespace NDC_Core_DataBridge.Setup
{
    public static class Setup
    {
        /// <summary>
        /// Configures the DbContext and registers services for dependency injection.
        /// </summary>
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<NdcCoreDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}
