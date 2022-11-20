using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wpf_Databastenknik_Assignment1.Contexts;
using Wpf_Databastenknik_Assignment1.Services;

namespace Wpf_Databastenknik_Assignment1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? app { get; private set; }


        public App()
        {
            app = Host.CreateDefaultBuilder().ConfigureServices(services => 
            {
                services.AddScoped<MainWindow>();
                services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\robin\Desktop\Databasteknik-Assignment1\Databasteknik-Assignment1\WebApi_Databasteknik-Assignment1\Contexts\Local_Sql_Db.mdf;Integrated Security=True;Connect Timeout=30"));
                services.AddScoped<CustomerService>();
                services.AddScoped<ProductService>();
                services.AddScoped<OrderService>();

            }).Build(); 

        }

        protected override async void OnStartup(StartupEventArgs e) 
        {
            await app!.StartAsync();
            var MainWindow = app.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);  
        }
    }
}
