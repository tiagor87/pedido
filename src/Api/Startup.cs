using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using UnifesoPoo.Pedido.Api.Controllers.Middlewares;
using UnifesoPoo.Pedido.Api.Controllers.Parsers;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.AppServices;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Contracts;
using UnifesoPoo.Pedido.Api.Core.Application.ProductAgg.Parsers;
using UnifesoPoo.Pedido.Api.Core.Domain.EstoqueAgg.Repositories;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Entities;
using UnifesoPoo.Pedido.Api.Core.Domain.ProductAgg.Repositories;
using UnifesoPoo.Pedido.Api.Core.Domain.Shared.Repositories;
using UnifesoPoo.Pedido.Api.Core.Infrastructure.EstoqueAgg.Repositories;
using UnifesoPoo.Pedido.Api.Core.Infrastructure.ProductAgg.Repositories;
using UnifesoPoo.Pedido.Api.Core.Infrastructure.Shared;

namespace UnifesoPoo.Pedido.Api
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
            services.AddCors(options =>
            {
                options.AddPolicy("all", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
                
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UnifesoPoo.Pedido.Api", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "UnifesoPoo.Pedido.Api.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddDbContext<PedidoDbContext>(options =>
            {
                options
                    .UseSqlite(Configuration.GetConnectionString("Sqlite"));
            });

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<ProdutoAppService>();
            services.AddScoped<ProdutoReportParser>();
            services.AddScoped<IProdutoParseFactory, ProdutoParseFactory>();
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<PedidoDbContext>());
            services.AddMediatR(Assembly.GetEntryAssembly());
            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://tiagor87.auth0.com/";
                options.Audience = "https://pedido-api.unifeso-poo.com.br";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PedidoDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                dbContext.Database.EnsureCreated();
                dbContext.Database.Migrate();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UnifesoPoo.Pedido.Api v1"));
            }

            app.UseCors("all");
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapControllers()
                    .RequireAuthorization();
            });
        }
    }
}
