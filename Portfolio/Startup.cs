using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portfolio.Core;
using Portfolio.Data;
using Portfolio.Data.dbData;
using Portfolio.Data.InMemory;

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

            services.AddSingleton<IPablosData, InMemoryInformation>();
            AddInMemoryDaos(services);  // Uncomment this to work wiht In Memory data
            //AddSqlDaos(services);     // Uncomment this for working with data in SQL Server

            services.AddRazorPages();
        }
        public void AddSqlDaos(IServiceCollection services)
        {

        }

        public void AddInMemoryDaos(IServiceCollection services)
        {
            services.AddSingleton<IRepository<Education>, InMemoryEducationDao>();
            services.AddSingleton<IRepository<Experience>, InMemoryExperienceDao>();
            services.AddSingleton<IRepository<Project>, InMemoryProjectDao>();
            services.AddSingleton<IRepository<Skill>, InMemorySkillsDao>();
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
