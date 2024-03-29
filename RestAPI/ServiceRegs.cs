﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using vxnet.Domain.Context;
using vxnet.Domain.Repository;
using vxnet.Domain.Service;
using vxnet.DTOs.Models;

namespace vxnet.RestAPI
{
    public static class ServiceRegs
    {
        public static void RegisterDependecies(this IServiceCollection services, IConfiguration configuration)
        {
            DBContext(services, configuration);
            AuthTokens(services, configuration);
            Repos(services);
            JwtSettings(services, configuration);
            Services(services);
        }

        static void DBContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        static void Repos(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepo<>), typeof(Repo<>));
        }

        static void JwtSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtDTO>(configuration.GetSection("Jwt"));
            services.AddScoped<IJwtGenerator, JwtGenerator>();
        }

        static void Services(IServiceCollection services)
        {
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAppRegService, AppRegService>();
        }

        static void AuthTokens(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true, 
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
