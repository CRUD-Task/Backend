using EmployeeApp.Domain.Interfaces;
using EmployeeApp.Application.Common.Interfaces;
using EmployeeApp.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
