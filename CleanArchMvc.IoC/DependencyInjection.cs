using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAPIMocoratti.Repository.Interfaces;


namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {

            //MigrationsAssembly indica onde será criada a pasta migrations 
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductServices, ProductService>();
            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(myhandlers));
            return services;
        }
    }
}
