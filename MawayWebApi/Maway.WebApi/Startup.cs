using AutoMapper;
using FluentValidation.AspNetCore;
using Maway.Data;
using Maway.WebApi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Maway.BusinessLogic.Queries;
using Maway.BusinessLogic.Services.Abstract;
using Maway.BusinessLogic.Services.Implementation;

namespace Maway.WebApi
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
                options.AddPolicy("MyPolicy",
                builder =>
                {
                    builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GetAvailableItemsQuery>());
            services.AddMediatR(Assembly.GetAssembly(typeof(GetAvailableItemsQuery)));
            services.AddScoped<IPriceCalculationService, PriceCalculationService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.SeedDb();
            }

            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 docs");
            });
        }
    }
}
