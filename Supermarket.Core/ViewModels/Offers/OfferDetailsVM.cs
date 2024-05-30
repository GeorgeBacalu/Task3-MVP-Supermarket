using Supermarket.Core.Dtos.Common;
using Supermarket.Core.ViewModels.Commands;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Offers
{
    public class OfferDetailsVM : BaseVM
    {
        public OfferDto OfferDto { get; set; }

        public ICommand BackCommand { get; }

        public OfferDetailsVM(OfferDto offerDto)
        {
            OfferDto = offerDto;
            BackCommand = new RelayCommand(o => Back());
        }

        private void Back() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}