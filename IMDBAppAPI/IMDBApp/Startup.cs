using IMDB.Repository.Interfaces;
using IMDBApp.Repository.Classes;
using IMDBAppAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace IMDBAppAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the DI container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder => { builder.WithOrigins("localhost:5500").AllowAnyHeader().AllowAnyMethod(); });
            });
            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));

            // services.AddScoped() - Scope is complete HTTP Request cycle.
            // services.AddTransient() - Scope is limited to once per usage
            // services.AddSingleton() - Scope is till application running

          
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IProducerService, ProducerService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                    Version = "1.0",
                    Title = "IMDBAppAPI"
                });
            });

        }

        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
        }
    }
}