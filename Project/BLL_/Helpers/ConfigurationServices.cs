using DAL_.Context;
using DAL_.Entyties;
using DAL_.Interfaces;
using DAL_.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL_.Helpers
{
    public static class ConfigurationServices
    {
        public static void ConfigureServices(IServiceCollection services, string connString)
        {
            services.AddDbContext<BlogContext>(options =>
                options.UseSqlServer(connString));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<BlogContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<UnitOfWork>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
