﻿using Business.Abstract;
using Business.Concrete;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Ecryption;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // IoC Container
            services.AddControllers();

            services.AddCors();

            //services.AddSingleton<IRentalService, RentalManager>();  // Eðer contructor'da IRentalService çalışıyorsa arkaplanda CarManager new'i verir.
            //services.AddSingleton<IRentalDal, EfRentalDal>();

            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<IUserDal, EfUserDal>();

            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<ICarDal, EfCarDal>();

            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();

            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IColorDal, EfColorDal>();

            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IBrandDal, EfBrandDal>();
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidIssuer = tokenOptions.Issuer,
                            ValidAudience = tokenOptions.Audience,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                        };
                    });
            services.AddDependencyResolvers(new ICoreModule[] { new CoreModule() });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4201", "http://localhost:4202").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
