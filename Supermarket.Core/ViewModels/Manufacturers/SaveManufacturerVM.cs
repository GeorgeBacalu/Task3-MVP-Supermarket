using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Manufacturers
{
    public class SaveManufacturerVM : BaseVM
    {
        private readonly IManufacturerService _manufacturerService;
        public ManufacturerDto ManufacturerDto { get; set; }
        public string Title { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public SaveManufacturerVM(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
            ManufacturerDto = new ManufacturerDto();
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Add Manufacturer";
        }

        public SaveManufacturerVM(IManufacturerService manufacturerService, ManufacturerDto manufacturerDto)
        {
            _manufacturerService = manufacturerService;
            ManufacturerDto = manufacturerDto;
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Update Manufacturer";
        }

        private void Save()
        {
            if (ManufacturerDto.Id == Guid.Empty)
                _manufacturerService.Add(ManufacturerDto);
            else
                _manufacturerService.UpdateById(ManufacturerDto, ManufacturerDto.Id);
            Cancel();
        }

        private void Cancel() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}