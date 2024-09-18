using Asp.Versioning;
using HairSalon.Core.Contracts;
using HairSalon.Core.Contracts.Repositories;
using HairSalon.Core.Contracts.Services;
using HairSalon.Dto;
using HairSalon.Infrastructure;
using HairSalon.Infrastructure.Repositories;
using HairSalon.Service;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(opt =>
            {
                //opt.SuppressModelStateInvalidFilter = true;
                //opt.SuppressInferBindingSourcesForParameters = true;
                //opt.SuppressConsumesConstraintForFormFileParameters = true;
            }).AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.WriteIndented = true;
                opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "HairSalon.API",
                    Description = "An ASP.NET Core Web API for HairSalon project - PRN231",
                    Version = "v1",
                });
                opt.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by a space and your JWT token in the text input below. Example: 'Bearer abcdef12345'."
                });
                opt.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference()
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });

                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });
            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfileExtension));
            services.AddApplicationServices();
            services.AddApiVersioning();

            // Database connection string
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
            var connectionString = config.GetConnectionString("DefaultConnection") ?? string.Empty;
            services.AddDatabase(connectionString);

            services.AddCors(opt =>
            {
                // TODO: Change the URL in WithOrigins to the client URL
                opt.AddPolicy("HairSalon", builder =>
                {
                    builder.WithOrigins(string.Empty)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            return services;
        }

        /// <summary>
        /// Inject application service, including repositories, services, etc.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Services, Unit of Work
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();  
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();  
            services.AddScoped<IServiceRepository, ServiceRepository>();  
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();  

            return services;
        }

        /// <summary>
        /// Configure Api versioning using URL segment and header
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        private static IServiceCollection AddApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.DefaultApiVersion = new ApiVersion(1);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
                opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new HeaderApiVersionReader("X-Api-Version"));
            })
            .AddApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'V";
                opt.SubstituteApiVersionInUrl = true;
            });
            return services;
        }

        /// <summary>
        /// Database configuration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<HairSalonDbContext>(opt => opt.UseSqlServer(connectionString, sqlOptions => sqlOptions.CommandTimeout(120)));

            return services;
        }
    }
}
