using AutoService.BLL.Mapping;
using AutoService.BLL.Services;
using AutoService.BLL.Services.Interfaces;
using AutoService.Core.Data.Context;
using AutoService.Core.Entities;
using AutoService.Core.Entities.Abstract;
using AutoService.DataAccess.Repositories.Base;
using AutoService.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Amado.BLL.DIContainer
{
    public static class DIContainer
    {
        public static IServiceCollection AddDIContainer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AutoServiceContext>(x =>
                x.UseLazyLoadingProxies().UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("AutoService.DataAccess")));

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.SignIn.RequireConfirmedEmail = false;
                opt.SignIn.RequireConfirmedPhoneNumber = false;

                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = true;
            })
                .AddEntityFrameworkStores<AutoServiceContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(x =>
            {
                x.LoginPath = new PathString("/User/Login");
                x.LogoutPath = new PathString("/User/Logout");
                x.AccessDeniedPath = new PathString("/User/Denied");
                x.Cookie = new CookieBuilder
                {
                    Name = "AmadoAuthCookie", 
                    HttpOnly = false, 
                    SameSite = SameSiteMode.Lax, 
                    SecurePolicy = CookieSecurePolicy.Always 
                };
                x.SlidingExpiration = true;
                x.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });

            services.AddScoped<IRepository<BaseEntity>, BaseRepository<BaseEntity>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
