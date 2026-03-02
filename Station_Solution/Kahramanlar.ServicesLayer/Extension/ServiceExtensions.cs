using Kahramanlar.ServicesLayer.Services.Fatura;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kahramanlar.ServicesLayer.Extension
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IFaturaService, FaturaService>();

            return services;
        }
    }
}
