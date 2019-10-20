using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Library;
using Library.Library.Repository;
using Library.Library.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LibraryProject
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
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services
                .AddTransient<IBookRepository, BookRepository>()
                .AddTransient<IBookService, BookService>()
                .AddTransient<IStudentRepository, StudentRepository>()
                .AddTransient<IStudentService, StudentService>()
                .AddTransient<IIssueRepository, IssueRepository>()
                .AddTransient<IIssueService, IssueService>()
                .AddTransient<IReportService, ReportService>()
                .AddTransient<UnitOfWork>(x => new UnitOfWork(connectionString, migrationAssemblyName))
                .AddTransient<LibraryContext>(x => new LibraryContext(connectionString, migrationAssemblyName));
         
            services.AddDbContext<LibraryContext>(x => x.UseSqlServer(connectionString, m => m.MigrationsAssembly(migrationAssemblyName)));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
