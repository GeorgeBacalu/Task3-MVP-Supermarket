using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using Supermarket.Core.Views.Stocks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace Supermarket.Core.ViewModels.Stocks
{
    public class StocksVM : BaseVM
    {
        private readonly IStockService _stockService;
        private readonly IProductService _productService;
        public ObservableCollection<StockDto> StockDtos { get; set; }
        public string SearchKey { get; set; }
        public event Action OnClose;

        public ICommand AddStockCommand { get; }
        public ICommand UpdateStockCommand { get; }
        public ICommand DeleteStockCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand CloseCommand { get; }

        public StocksVM(IStockService stockService, IProductService productService)
        {
            _stockService = stockService;
            _productService = productService;
            LoadProductsForStocks();
            StockDtos = new ObservableCollection<StockDto>(_stockService.GetAll());
            AddStockCommand = new RelayCommand(o => AddStock());
            UpdateStockCommand = new RelayCommand(o => UpdateStock(o as StockDto));
            DeleteStockCommand = new RelayCommand(o => DeleteStock(o as StockDto));
            ViewDetailsCommand = new RelayCommand(o => ViewDetails(o as StockDto));
            SearchCommand = new RelayCommand(o => GetByKey());
            CloseCommand = new RelayCommand(o => OnClose?.Invoke());
        }

        private void LoadProductsForStocks()
        {
            var stocks = _stockService.GetAll();
            foreach (var stock in stocks)
            {
                stock.ProductDto = _productService.GetById(stock.ProductId);
            }
            StockDtos = new ObservableCollection<StockDto>(stocks);
        }

        private void AddStock()
        {
            var saveStockView = new SaveStockView(new SaveStockVM(_stockService, _productService));
            saveStockView.ShowDialog();
            RefreshStocks();
        }

        private void UpdateStock(StockDto stockDto)
        {
            var saveStockView = new SaveStockView(new SaveStockVM(_stockService, _productService, stockDto));
            saveStockView.ShowDialog();
            RefreshStocks();
        }

        private void DeleteStock(StockDto stockDto)
        {
            _stockService.DeleteById(stockDto.Id);
            RefreshStocks();
        }

        private void ViewDetails(StockDto stockDto)
        {
            var stockDetailsView = new StockDetailsView(new StockDetailsVM(stockDto));
            stockDetailsView.ShowDialog();
        }

        private void GetByKey()
        {
            StockDtos = new ObservableCollection<StockDto>(_stockService.GetByKey(SearchKey));
            OnPropertyChanged(nameof(StockDtos));
        }

        private void RefreshStocks()
        {
            StockDtos = new ObservableCollection<StockDto>(_stockService.GetAll());
            OnPropertyChanged(nameof(StockDtos));
        }
    }
}