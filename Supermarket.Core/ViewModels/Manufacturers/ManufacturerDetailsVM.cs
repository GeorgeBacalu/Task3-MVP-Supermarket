using Supermarket.Core.Dtos.Common;
using Supermarket.Core.ViewModels.Commands;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Manufacturers
{
    public class ManufacturerDetailsVM : BaseVM
    {
        public ManufacturerDto ManufacturerDto { get; set; }

        public ICommand BackCommand { get; }

        public ManufacturerDetailsVM(ManufacturerDto manufacturerDto)
        {
            ManufacturerDto = manufacturerDto;
            BackCommand = new RelayCommand(o => Back());
        }

        private void Back() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}