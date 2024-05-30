using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using Supermarket.Core.Views.Products;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace Supermarket.Core.ViewModels.Products
{
    public class ProductsVM : BaseVM
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;
        public ObservableCollection<ProductDto> ProductDtos { get; set; }
        public string SearchKey { get; set; }
        public event Action OnClose;

        public ICommand AddProductCommand { get; }
        public ICommand UpdateProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand CloseCommand { get; }

        public ProductsVM(IProductService productService, ICategoryService categoryService, IManufacturerService manufacturerService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
            ProductDtos = new ObservableCollection<ProductDto>(_productService.GetAll());
            AddProductCommand = new RelayCommand(o => AddProduct());
            UpdateProductCommand = new RelayCommand(o => UpdateProduct(o as ProductDto));
            DeleteProductCommand = new RelayCommand(o => DeleteProduct(o as ProductDto));
            ViewDetailsCommand = new RelayCommand(o => ViewDetails(o as ProductDto));
            SearchCommand = new RelayCommand(o => GetByKey());
            CloseCommand = new RelayCommand(o => OnClose?.Invoke());
        }

        private void AddProduct()
        {
            var saveProductView = new SaveProductView(new SaveProductVM(_productService, _categoryService, _manufacturerService));
            saveProductView.ShowDialog();
            RefreshProducts();
        }

        private void UpdateProduct(ProductDto productDto)
        {
            var saveProductView = new SaveProductView(new SaveProductVM(_productService, _categoryService, _manufacturerService, productDto));
            saveProductView.ShowDialog();
            RefreshProducts();
        }

        private void DeleteProduct(ProductDto productDto)
        {
            _productService.DeleteById(productDto.Id);
            RefreshProducts();
        }

        private void ViewDetails(ProductDto productDto)
        {
            var productDetailsView = new ProductDetailsView(new ProductDetailsVM(productDto));
            productDetailsView.ShowDialog();
        }

        private void GetByKey()
        {
            ProductDtos = new ObservableCollection<ProductDto>(_productService.GetByKey(SearchKey));
            OnPropertyChanged(nameof(ProductDtos));
        }

        private void RefreshProducts()
        {
            ProductDtos = new ObservableCollection<ProductDto>(_productService.GetAll());
            OnPropertyChanged(nameof(ProductDtos));
        }
    }
}