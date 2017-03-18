using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MVCLab2.Models.Repositories;
using Microsoft.Extensions.Configuration;
using MVCLab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MVCLab2
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:CommunityConnection"]));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["ConnectionStrings:IdentityConnection"]));

            services.AddIdentity<User, IdentityRole>(options =>
            { options.Cookies.ApplicationCookie.LoginPath = "/Login/Login"; })
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddIdentity<User, IdentityRole>(options => options.Cookies.ApplicationCookie.AccessDeniedPath = "/Error/Error");

            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseIdentity();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseSession();
            SeedData.EnsurePopulated(app);
        }
    }
}
