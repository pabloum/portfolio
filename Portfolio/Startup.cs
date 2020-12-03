using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.Entities.Entities;
using Portfolio.Data;
using Portfolio.Data.dbData;
using Portfolio.Data.InMemory;
using Services;
using Portfolio.Services.Services;

namespace Portfolio
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
            services.AddDbContextPool<PortfolioDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("PortfolioDb"));
            });

            ////The context options could be singleton, not the context instance because each request has a scoped lifetime - atomic transactions)
            var contextOptions = new DbContextOptionsBuilder<PortfolioDbContext>().UseSqlServer(Configuration.GetConnectionString("PortfolioDb"), options => options.EnableRetryOnFailure()).Options;
            services.AddSingleton(contextOptions);

            services.AddAutoMapper(typeof(Startup));

            var typeOfData = Configuration.GetValue<string>("Data");

            if (typeOfData == "InMemory")
            {
                AddInMemoryDaos(services);
            }
            else if (typeOfData == "Sql")
            {
                AddSqlDaos(services);
            }
            else 
            {
                throw new Exception("No type of data specified");
            }

            AddServices(services);

            services.AddRazorPages();

            services.AddMvc(opt => opt.EnableEndpointRouting = false);
        }
        public void AddSqlDaos(IServiceCollection services)
        {
            services.AddScoped<IOldRepository, OldRepository>();

            services.AddScoped<IDao<Education>, SqlEducationDao>();
            services.AddScoped<IDao<Experience>, SqlExperienceDao>();
            services.AddScoped<IDao<Project>, SqlProjectDao>();
            services.AddScoped<IDao<Skill>, SqlSkillsDao>();

            services.AddScoped<IRepository<Education>, EducationRepository>();
            services.AddScoped<IRepository<Experience>, ExperienceRepository>();
            services.AddScoped<IRepository<Project>, ProjectRepository>();
            services.AddScoped<IRepository<Skill>, SkillRepository>();
        }

        public void AddInMemoryDaos(IServiceCollection services)
        {
            services.AddSingleton<IOldRepository, OldRepository>();

            services.AddSingleton<IDao<Education>, InMemoryEducationDao>();
            services.AddSingleton<IDao<Experience>, InMemoryExperienceDao>();
            services.AddSingleton<IDao<Project>, InMemoryProjectDao>();
            services.AddSingleton<IDao<Skill>, InMemorySkillsDao>();

            services.AddSingleton<IRepository<Education>, InMemoryEducationRepository>();
            services.AddSingleton<IRepository<Experience>, InMemoryExperienceRepository>();
            services.AddSingleton<IRepository<Project>, InMemoryProjectRepository>();
            services.AddSingleton<IRepository<Skill>, InMemorySkillRepository>();
        }

        public void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBaseService<Education>, EducationService>();
            services.AddScoped<IBaseService<Experience>, ExperienceService>();
            services.AddScoped<IBaseService<Project>, ProjectsService>();
            services.AddScoped<IBaseService<Skill>, SkillService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
