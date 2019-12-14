using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NPD.API.Middlewares;
using NPD.API.Validations;
using NPD.Domain.Entities.PersonAggreagete;
using NPD.Domain.Interfaces;
using NPD.Domain.Services;
using NPD.Infrastructure.Context;
using NPD.Infrastructure.Repositories;
using NPD.Infrastructure.Services;
using System.Reflection;

namespace NPD.API
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
            services.AddDbContext<NPDContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("NPDDB"))
                );

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IExceptionStorage, ExceptionStorage>();
            services.AddScoped<IImageStoreage, ImageStoreage>();

            services.AddScoped<IPersonPresenterService, PersonPresenterService>();

            services.AddScoped<ImageManager>();
            services.AddScoped<ICurrentDateProvider, DateProvider>();


            services.AddControllers(conf =>
            {
                //conf.Filters.Add(typeof(RequestValidationActionFilter)); //Secret key validation
                //conf.Filters.Add(typeof(ExceptionFilter)); //Eception handling done by filter
            })
            .AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<CreatePersonCommandValidation>());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAcceptHeadersSetMiddleware();
            app.UseExceptionLoggerMiddleware();

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
