using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecard.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ecard
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
            services.AddMvc();

            //WOWOCO: let MVC Services know about my database
            //services.AddDbContext<Enter-DB-Bridge-class>(options => options.UsesSqlite(Configuration["Enter-DB-Name"]));
            services.AddDbContext<DbBridge>(options => options.UseSqlite(Configuration["MyDB"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();


            //DWOWOCO: Codeblock to auto-create the database when needed
            //Copy & Paste  AS-IS, EXCEPT FOR .GetServices<DATABASE-CLASS-NAME>
            using (var serviceScope = app
                .ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())

            {
                serviceScope
                    .ServiceProvider
                    .GetService<DbBridge>()
                    .Database
                    .EnsureCreated();



            }

        }
    }
}
