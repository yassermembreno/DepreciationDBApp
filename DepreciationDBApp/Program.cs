using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Applications.Services;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using DepreciationDBApp.Forms;
using DepreciationDBApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DepreciationDBApp
{
    static class Program
    {
        public static IConfiguration Configuration;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configuration = new ConfigurationBuilder()                
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables().Build();             

            //var builder = new HostBuilder().ConfigureServices((hostContext, services) =>
            //{
            //    services.AddDbContext<DepreciationDBContext>(options =>
            //    {
            //        options.UseSqlServer(Configuration.GetConnectionString("Default"));
            //    });
            //});

            //var host = builder.Build();
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            
            services.AddDbContext<DepreciationDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IDepreciationDbContext, DepreciationDBContext>();
            services.AddScoped<IAssetRepository, EFAssetRepository>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<Form1>();

            using (var serviceScope = services.BuildServiceProvider())
            {
                var main = serviceScope.GetRequiredService<Form1>();
                Application.Run(main);
            }            
          
        }
    }
}
