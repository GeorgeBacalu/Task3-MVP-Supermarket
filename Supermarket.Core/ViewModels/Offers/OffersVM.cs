using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using Supermarket.Core.Views.Offers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace Supermarket.Core.ViewModels.Offers
{
    public class OffersVM : BaseVM
    {
        private readonly IOfferService _offerService;
        private readonly IProductService _productService;
        public ObservableCollection<OfferDto> OfferDtos { get; set; }
        public string SearchKey { get; set; }
        public event Action OnClose;

        public ICommand AddOfferCommand { get; }
        public ICommand UpdateOfferCommand { get; }
        public ICommand DeleteOfferCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand CloseCommand { get; }

        public OffersVM(IOfferService offerService, IProductService productService)
        {
            _offerService = offerService;
            _productService = productService;
            OfferDtos = new ObservableCollection<OfferDto>(_offerService.GetAll());
            AddOfferCommand = new RelayCommand(o => AddOffer());
            UpdateOfferCommand = new RelayCommand(o => UpdateOffer(o as OfferDto));
            DeleteOfferCommand = new RelayCommand(o => DeleteOffer(o as OfferDto));
            ViewDetailsCommand = new RelayCommand(o => ViewDetails(o as OfferDto));
            SearchCommand = new RelayCommand(o => GetByKey());
            CloseCommand = new RelayCommand(o => OnClose?.Invoke());
        }

        private void AddOffer()
        {
            var saveOfferView = new SaveOfferView(new SaveOfferVM(_offerService, _productService));
            saveOfferView.ShowDialog();
            RefreshOffers();
        }

        private void UpdateOffer(OfferDto offerDto)
        {
            var saveOfferView = new SaveOfferView(new SaveOfferVM(_offerService, _productService, offerDto));
            saveOfferView.ShowDialog();
            RefreshOffers();
        }

        private void DeleteOffer(OfferDto offerDto)
        {
            _offerService.DeleteById(offerDto.Id);
            RefreshOffers();
        }

        private void ViewDetails(OfferDto offerDto)
        {
            var offerDetailsView = new OfferDetailsView(new OfferDetailsVM(offerDto));
            offerDetailsView.ShowDialog();
        }

        private void GetByKey()
        {
            OfferDtos = new ObservableCollection<OfferDto>(_offerService.GetByKey(SearchKey));
            OnPropertyChanged(nameof(OfferDtos));
        }

        private void RefreshOffers()
        {
            OfferDtos = new ObservableCollection<OfferDto>(_offerService.GetAll());
            OnPropertyChanged(nameof(OfferDtos));
        }
    }
}