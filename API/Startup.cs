using System.Reflection;
using API.Extensions;
using API.Middleware;
using Core;
using Core.Common.Mappings;
using Core.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddScoped<IPortalContext, PortalContext>();
            // services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

            services.AddDbContext<PortalContext>(x => 
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

            services.AddControllers();
            // services.AddSwaggerGen(c =>
            // {
            //     c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            // });

              services.AddAutoMapper(config =>
           {
               config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
               config.AddProfile(new AssemblyMappingProfile(typeof(IPortalContext).Assembly));
           });
 
            services.AddApplication();
            services.AddPersistence(_config);
 
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    // policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            //  services.Configure<ApiBehaviorOptions>(options => {
            //     options.InvalidModelStateResponseFactory = actionContext => 
            //     {
            //         var errors = actionContext.ModelState
            //             .Where(e => e.Value.Errors.Count > 0)
            //             .SelectMany(x => x.Value.Errors)
            //             .Select(x => x.ErrorMessage).ToArray();
 
 
            //             var errorResponse = new ApiValidationErrorResponse
            //             {
            //                 Errors = errors
            //             };
 
            //             return new BadRequestObjectResult(errorResponse);
            //     };
            // });
             services.AddApplicationServices();
            services.AddSwaggerDocumentation();
 

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                
                // app.UseDeveloperExceptionPage();
                // app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
                app.UseSwaggerDocumentation();
            }

            // app.UseMiddleware<ExceptionMiddleware>();

             app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
