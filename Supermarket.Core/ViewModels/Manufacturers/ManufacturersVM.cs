using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using Supermarket.Core.Views.Manufacturers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace Supermarket.Core.ViewModels.Manufacturers
{
    public class ManufacturersVM : BaseVM
    {
        private readonly IManufacturerService _manufacturerService;
        public ObservableCollection<ManufacturerDto> Manufacturers { get; set; }
        public string SearchKey { get; set; }
        public event Action OnClose;

        public ICommand AddManufacturerCommand { get; }
        public ICommand UpdateManufacturerCommand { get; }
        public ICommand DeleteManufacturerCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand CloseCommand { get; }

        public ManufacturersVM(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
            Manufacturers = new ObservableCollection<ManufacturerDto>(_manufacturerService.GetAll());
            AddManufacturerCommand = new RelayCommand(o => AddManufacturer());
            UpdateManufacturerCommand = new RelayCommand(o => UpdateManufacturer(o as ManufacturerDto));
            DeleteManufacturerCommand = new RelayCommand(o => DeleteManufacturer(o as ManufacturerDto));
            ViewDetailsCommand = new RelayCommand(o => ViewDetails(o as ManufacturerDto));
            SearchCommand = new RelayCommand(o => GetByKey());
            CloseCommand = new RelayCommand(o => OnClose?.Invoke());
        }

        private void AddManufacturer()
        {
            var saveManufacturerView = new SaveManufacturerView(new SaveManufacturerVM(_manufacturerService));
            saveManufacturerView.ShowDialog();
            RefreshManufacturers();
        }

        private void UpdateManufacturer(ManufacturerDto manufacturerDto)
        {
            var saveManufacturerView = new SaveManufacturerView(new SaveManufacturerVM(_manufacturerService, manufacturerDto));
            saveManufacturerView.ShowDialog();
            RefreshManufacturers();
        }

        private void DeleteManufacturer(ManufacturerDto manufacturerDto)
        {
            _manufacturerService.DeleteById(manufacturerDto.Id);
            RefreshManufacturers();
        }

        private void ViewDetails(ManufacturerDto manufacturerDto)
        {
            var manufacturerDetailsView = new ManufacturerDetailsView(new ManufacturerDetailsVM(manufacturerDto));
            manufacturerDetailsView.ShowDialog();
        }

        private void GetByKey()
        {
            Manufacturers = new ObservableCollection<ManufacturerDto>(_manufacturerService.GetByKey(SearchKey));
            OnPropertyChanged(nameof(Manufacturers));
        }

        private void RefreshManufacturers()
        {
            Manufacturers = new ObservableCollection<ManufacturerDto>(_manufacturerService.GetAll());
            OnPropertyChanged(nameof(Manufacturers));
        }
    }
}