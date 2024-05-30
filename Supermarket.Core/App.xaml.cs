using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Supermarket.Core.Context;
using Supermarket.Core.Repositories;
using Supermarket.Core.Repositories.Interfaces;
using Supermarket.Core.Services;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels;
using Supermarket.Core.ViewModels.Categories;
using Supermarket.Core.ViewModels.Manufacturers;
using Supermarket.Core.ViewModels.Offers;
using Supermarket.Core.ViewModels.Products;
using Supermarket.Core.ViewModels.Receipts;
using Supermarket.Core.ViewModels.Stocks;
using Supermarket.Core.ViewModels.Users;
using Supermarket.Core.Views.Auth;
using Supermarket.Core.Views.Categories;
using Supermarket.Core.Views.Manufacturers;
using Supermarket.Core.Views.Offers;
using Supermarket.Core.Views.Products;
using Supermarket.Core.Views.Receipts;
using Supermarket.Core.Views.Stocks;
using Supermarket.Core.Views.Users;
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
            services.AddTransient<UsersView>();
            services.AddTransient<SaveUserView>();
            services.AddTransient<UserDetailsView>();
            services.AddTransient<CategoriesView>();
            services.AddTransient<SaveCategoryView>();
            services.AddTransient<CategoryDetailsView>();
            services.AddTransient<ManufacturersView>();
            services.AddTransient<SaveManufacturerView>();
            services.AddTransient<ManufacturerDetailsView>();
            services.AddTransient<OffersView>();
            services.AddTransient<SaveOfferView>();
            services.AddTransient<OfferDetailsView>();
            services.AddTransient<ProductsView>();
            services.AddTransient<SaveProductView>();
            services.AddTransient<ProductDetailsView>();
            services.AddTransient<ReceiptsView>();
            services.AddTransient<SaveReceiptView>();
            services.AddTransient<ReceiptDetailsView>();
            services.AddTransient<StocksView>();
            services.AddTransient<SaveStockView>();
            services.AddTransient<StockDetailsView>();

            services.AddTransient<MainVM>();
            services.AddTransient<UsersVM>();
            services.AddTransient<SaveUserVM>();
            services.AddTransient<UserDetailsVM>();
            services.AddTransient<CategoriesVM>();
            services.AddTransient<SaveCategoryVM>();
            services.AddTransient<CategoryDetailsVM>();
            services.AddTransient<ManufacturersVM>();
            services.AddTransient<SaveManufacturerVM>();
            services.AddTransient<ManufacturerDetailsVM>();
            services.AddTransient<OffersVM>();
            services.AddTransient<SaveOfferVM>();
            services.AddTransient<OfferDetailsVM>();
            services.AddTransient<ProductsVM>();
            services.AddTransient<SaveProductVM>();
            services.AddTransient<ProductDetailsVM>();
            services.AddTransient<ReceiptsVM>();
            services.AddTransient<SaveReceiptVM>();
            services.AddTransient<ReceiptDetailsVM>();
            services.AddTransient<StocksVM>();
            services.AddTransient<SaveStockVM>();
            services.AddTransient<StockDetailsVM>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            var supermarketView = _host.Services.GetRequiredService<SupermarketView>();
            var authVM = _host.Services.GetRequiredService<MainVM>();
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