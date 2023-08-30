using System.Reflection;
using Carts.Application;
using Carts.Application.Common.Mapping;
using Carts.Application.Interfaces;
using Carts.Persistence;
using Carts.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Npgsql;

namespace Carts.WebApi
{
    public class Startup
    {
        // инициализация конфигурации данных
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {

            // инициализация автоматического маппинга по необходимым интерфейсам контекстов каждой из таблиц
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ICartsDBContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(IGoodsDBContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            // разрешение методов передачи данных
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            // генерация xml файла для Swagger
            services.AddSwaggerGen(cfg =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);
            });
            // инциализация метода авторизации в веб-апи
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer("Bearer", opt =>
                {
                    opt.Authority = "https://localhost:7275";
                    opt.Audience = "CartWebApi";
                    opt.RequireHttpsMetadata = false;
                });

            }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // инициализация Swagger
            app.UseSwagger();
            app.UseSwaggerUI(cfg =>
            {
                cfg.RoutePrefix = String.Empty;
                cfg.SwaggerEndpoint("swagger/v1/swagger.json", "RetailCarts API");
                cfg.DocumentTitle = "RetailCarts API V1";
            });
            
            app.ClientExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
        }
    }
}
