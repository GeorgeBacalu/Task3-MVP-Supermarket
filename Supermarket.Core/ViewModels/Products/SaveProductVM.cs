using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Products
{
    public class SaveProductVM : BaseVM
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IManufacturerService _manufacturerService;
        public ProductDto ProductDto { get; set; }
        public string Title { get; set; }

        public ObservableCollection<CategoryDto> Categories { get; set; }
        public ObservableCollection<ManufacturerDto> Manufacturers { get; set; }

        private CategoryDto selectedCategory;
        public CategoryDto SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                ProductDto.CategoryId = value?.Id ?? Guid.Empty;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private ManufacturerDto selectedManufacturer;
        public ManufacturerDto SelectedManufacturer
        {
            get => selectedManufacturer;
            set
            {
                selectedManufacturer = value;
                ProductDto.ManufacturerId = value?.Id ?? Guid.Empty;
                OnPropertyChanged(nameof(SelectedManufacturer));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public SaveProductVM(IProductService productService, ICategoryService categoryService, IManufacturerService manufacturerService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
            ProductDto = new ProductDto();
            Categories = new ObservableCollection<CategoryDto>(_categoryService.GetAll());
            Manufacturers = new ObservableCollection<ManufacturerDto>(_manufacturerService.GetAll());
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Add Product";
        }

        public SaveProductVM(IProductService productService, ICategoryService categoryService, IManufacturerService manufacturerService, ProductDto productDto)
        {
            _productService = productService;
            _categoryService = categoryService;
            _manufacturerService = manufacturerService;
            ProductDto = productDto;
            Categories = new ObservableCollection<CategoryDto>(_categoryService.GetAll());
            Manufacturers = new ObservableCollection<ManufacturerDto>(_manufacturerService.GetAll());
            SelectedCategory = Categories.FirstOrDefault(category => category.Id == ProductDto.CategoryId);
            SelectedManufacturer = Manufacturers.FirstOrDefault(manufacturer => manufacturer.Id == ProductDto.ManufacturerId);
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Update Product";
        }

        private void Save()
        {
            if (SelectedCategory == null || SelectedManufacturer == null)
            {
                MessageBox.Show("Please select a valid Category and Manufacturer.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            ProductDto.CategoryId = SelectedCategory.Id;
            ProductDto.ManufacturerId = SelectedManufacturer.Id;
            if (ProductDto.Id == Guid.Empty)
                _productService.Add(ProductDto);
            else
                _productService.UpdateById(ProductDto, ProductDto.Id);
            Cancel();
        }

        private void Cancel() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}