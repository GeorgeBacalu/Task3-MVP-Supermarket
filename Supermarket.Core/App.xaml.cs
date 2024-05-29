using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Supermarket.Core.Context;
using Supermarket.Core.Repositories;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels;
using Supermarket.Core.Views.Auth;
using System.Windows;

namespace Supermarket.Core
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App() => _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => ConfigureServices(services)).Build();

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SupermarketDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISoldProductRepository, SoldProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISoldProductService, SoldProductService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IUserService, UserService>();

            services.AddTransient<SupermarketView>();
            services.AddTransient<RegisterView>();
            services.AddTransient<LoginView>();

            services.AddTransient<AuthVM>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            var supermarketView = _host.Services.GetRequiredService<SupermarketView>();
            var authVM = _host.Services.GetRequiredService<AuthVM>();
            supermarketView.DataContext = authVM;
            supermarketView.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync().Wait();
            base.OnExit(e);
        }
    }
}