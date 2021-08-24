using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Exchange.Core.Item.Service;
using Exchange.Core.Item.Strategy;
using Exchange.Core.ItemTransaction.Service;
using Exchange.Core.ItemTransaction.Strategy;
using Exchange.Core.User.Service;
using Exchange.Core.User.Strategy;
using Exchange.Data.Sqlite;
using Exchange.Domain.DataInterfaces;
using Exchange.Domain.Item.Service;
using Exchange.Domain.Item.Strategy;
using Exchange.Domain.ItemTransaction.Service;
using Exchange.Domain.ItemTransaction.Strategy;
using Exchange.Domain.User.Service;
using Exchange.Domain.User.Strategy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Exchange.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            //    .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
            
            
            // var connection = "Data Source=imageinfo.db";
            services.AddDbContext<ExchangeDataContext>();
            
            
            
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemTransactionRepository, ItemTransactionRepository>();
            
            
            services.AddScoped<IItemReadService, ItemReadService>();
            services.AddScoped<IItemWriteService, ItemWriteService>();
            
            services.AddScoped<IUserReadService, UserReadService>();
            services.AddScoped<IUserWriteService, UserWriteService>();
            
            services.AddScoped<IItemTransactionReadService, ItemTransactionReadService>();
            services.AddScoped<IItemTransactionWriteService, ItemTransactionWriteService>();
            services.AddScoped<ICreateItemTransactionStrategy, CreateItemTransactionWithTransaction>();
            
            services.AddTransient<ItemWriteStrategySet>();
            services.AddScoped<ICreateItemStrategy, CreateItemWithTransaction>();
            services.AddScoped<IUpdateItemStrategy, UpdateItemWithTransaction>();
            services.AddScoped<IDeleteItemStrategy, DeleteItemSimple>();
            
            services.AddTransient<UserWriteStrategySet>();
            services.AddScoped<ICreateUserStrategy, CreateUserSimple>();
            services.AddScoped<IUpdateUserStrategy, UpdateUserSimple>();
            services.AddScoped<IDeleteUserStrategy, DeleteUserSimple>();
            

            
            services.AddControllers();
            
            services.AddSwaggerGen(SetSwaggerOptions);
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(SetJwtOptions);
        }

        private static void SetSwaggerOptions(SwaggerGenOptions generationOption)
        {
            generationOption.SwaggerDoc("v1", new OpenApiInfo() { Title = "Indg Exchange API", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            foreach (var xmlDocFile in Directory.GetFiles(AppContext.BaseDirectory,"Exchange.*.xml"))
            {
                generationOption.IncludeXmlComments(xmlDocFile);
            }

            generationOption.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                In = ParameterLocation.Header, 
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey 
            });

            generationOption.AddSecurityRequirement(new OpenApiSecurityRequirement {
                { 
                    new OpenApiSecurityScheme 
                    { 
                        Reference = new OpenApiReference 
                        { 
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer" 
                        } 
                    },
                    new string[] { } 
                } 
            });
        }

        private void SetJwtOptions(JwtBearerOptions options)
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = Configuration["Jwt:Audience"],
                ValidIssuer = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();

            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Exchange API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
