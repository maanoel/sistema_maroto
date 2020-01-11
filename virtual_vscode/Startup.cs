using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

using LojaVirtual.Model.Context;
using LojaVirtual.Business;
using LojaVirtual.Business.Implementations;
using LojaVirtual.Repository.Generic;

using LojaVirtual.HyperMedia;
using Swashbuckle.AspNetCore.Swagger;

using Tapioca.HATEOAS;
using LojaVirtual.Security.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using LojaVirtual.Repository.Implementations;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;

namespace LojaVirtual
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Connection to database
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            //Adding Migrations Support
            ExecuteMigrations(connectionString);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                _configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);




            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });
            
            //Content negociation - Support to XML and JSON
            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters();


            //HATEOAS filter definitions
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new BookEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());

            //Service inject
            services.AddSingleton(filterOptions);

            //Versioning
            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //Add Swagger Service
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "RESTful API With ASP.NET Core 2.0",
                        Version = "v1"
                    });

            });
            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();
            services.AddScoped<ILoginBusiness, LoginBusinessImpl>();
            services.AddScoped<IProductBusiness, ProductBusinessImpl>();
            services.AddScoped<ICarrinhoBusiness, CarrinhoBusinessImpl>();
            services.AddScoped<IFileBusiness, FileBusinessImpl>();
            services.AddScoped<IUserBusiness, UserBusinessImpl>();
            services.AddScoped<ISubstanceBusiness, SubstanceBusinessImpl>();
            services.AddScoped<ICommentBusiness, CommentBusinessImpl>();
            services.AddScoped<IPessoaBusiness, PessoaBusinessImpl>();
            services.AddScoped<IImovelBusiness, ImovelBusinessImpl>();
            services.AddScoped<IBoletoBusiness, BoletoBusinessImpl>();
            services.AddScoped<IImovelBusiness, ImovelBusinessImpl>();
            services.AddScoped<IReparoBusiness, ReparoBusinessImpl>();


            services.AddScoped<ICommentRepository, CommentRepositoryImpl>();
            services.AddScoped<ISubstanceRepository, SubstanceRepositoryImpl>();
            services.AddScoped<ICommentRepository, CommentRepositoryImpl>();
            services.AddScoped<IUserRepository, UserRepositoryImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
            services.AddScoped<IProductRepository, ProductRepositoryImpl>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepositoryImpl>();
            services.AddScoped<IPessoaRepository, PessoaRepositoryImpl>();
            services.AddScoped<IBoletoRepository, BoletoRepositoryImpl>();
            services.AddScoped<IImovelRepository, ImovelRepositoryImpl>();
            services.AddScoped<IReparoRepository, ReparoRepositoryImpl>();


            //Dependency Injection of GenericRepository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        private void ExecuteMigrations(string connectionString)
        {
            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve(Directory.GetCurrentDirectory() + "/db/Evolve.json", evolveConnection, msg => _logger.LogInformation(Directory.GetCurrentDirectory() + "\n" + msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();

                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();
            app.UseCookiePolicy(); ;
          

            //Enable Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            //Starting our API in Swagger page
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);


            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());

            //Adding map routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}");
            });


        }
    }
}
