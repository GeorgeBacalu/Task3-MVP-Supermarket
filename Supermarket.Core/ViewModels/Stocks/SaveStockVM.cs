using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Entities;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;

namespace Supermarket.Core.ViewModels.Stocks
{
    public class SaveStockVM : BaseVM
    {
        private readonly IStockService _stockService;
        private readonly IProductService _productService;
        public StockDto StockDto { get; set; }
        public string Title { get; set; }

        public ObservableCollection<ProductDto> Products { get; set; }
        public ObservableCollection<MeasureUnit> MeasureUnits { get; set; }

        private ProductDto selectedProduct;
        public ProductDto SelectedProduct 
        { 
            get => selectedProduct; 
            set 
            { 
                selectedProduct = value; 
                StockDto.ProductId = value?.Id ?? Guid.Empty; 
                OnPropertyChanged(nameof(SelectedProduct));
            } 
        }

        private MeasureUnit selectedMeasureUnit;
        public MeasureUnit SelectedMeasureUnit 
        { 
            get => selectedMeasureUnit; 
            set 
            { 
                selectedMeasureUnit = value; 
                StockDto.MeasureUnit = value; 
                OnPropertyChanged(nameof(SelectedMeasureUnit)); 
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public SaveStockVM(IStockService stockService, IProductService productService)
        {
            _stockService = stockService;
            _productService = productService;
            StockDto = new StockDto();
            Products = new ObservableCollection<ProductDto>(_productService.GetAll());
            MeasureUnits = new ObservableCollection<MeasureUnit>(Enum.GetValues(typeof(MeasureUnit)).Cast<MeasureUnit>());
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Add Stock";
        }

        public SaveStockVM(IStockService stockService, IProductService productService, StockDto stockDto)
        {
            _stockService = stockService;
            _productService = productService;
            StockDto = stockDto;
            Products = new ObservableCollection<ProductDto>(_productService.GetAll());
            MeasureUnits = new ObservableCollection<MeasureUnit>(Enum.GetValues(typeof(MeasureUnit)).Cast<MeasureUnit>());
            SelectedProduct = Products.FirstOrDefault(product => product.Id == StockDto.ProductId);
            SelectedMeasureUnit = StockDto.MeasureUnit;
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Update Stock";
        }

        private void Save()
        {
            if (StockDto.Id == Guid.Empty)
            {
                StockDto.ProductId = SelectedProduct.Id;
                StockDto.MeasureUnit = SelectedMeasureUnit;
                _stockService.Add(StockDto);
            }
            else
                _stockService.UpdateById(StockDto, StockDto.Id);
            Cancel();
        }

        private void Cancel() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}