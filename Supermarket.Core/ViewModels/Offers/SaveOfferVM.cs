using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;

namespace Supermarket.Core.ViewModels.Offers
{
    public class SaveOfferVM : BaseVM
    {
        private readonly IOfferService _offerService;
        private readonly IProductService _productService;

        public OfferDto OfferDto { get; set; }
        public string Title { get; set; }

        public ObservableCollection<ProductDto> Products { get; set; }

        private ProductDto selectedProduct;
        public ProductDto SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OfferDto.ProductId = value?.Id ?? Guid.Empty;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public SaveOfferVM(IOfferService offerService, IProductService productService)
        {
            _offerService = offerService;
            _productService = productService;
            OfferDto = new OfferDto();
            Products = new ObservableCollection<ProductDto>(_productService.GetAll());
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Add Offer";
        }

        public SaveOfferVM(IOfferService offerService, IProductService productService, OfferDto offerDto)
        {
            _offerService = offerService;
            _productService = productService;
            OfferDto = offerDto;
            Products = new ObservableCollection<ProductDto>(_productService.GetAll());
            SelectedProduct = Products.FirstOrDefault(product => product.Id == OfferDto.ProductId);
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Update Offer";
        }

        private void Save()
        {
            if (OfferDto.Id == Guid.Empty)
                _offerService.Add(OfferDto);
            else
                _offerService.UpdateById(OfferDto, OfferDto.Id);
            Cancel();
        }

        private void Cancel() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}