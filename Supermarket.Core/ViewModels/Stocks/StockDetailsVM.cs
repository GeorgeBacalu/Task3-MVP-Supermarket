using Supermarket.Core.Dtos.Common;
using Supermarket.Core.ViewModels.Commands;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Stocks
{
    public class StockDetailsVM : BaseVM
    {
        public StockDto StockDto { get; set; }

        public ICommand BackCommand { get; }

        public StockDetailsVM(StockDto stockDto)
        {
            StockDto = stockDto;
            BackCommand = new RelayCommand(o => Back());
        }

        private void Back() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}