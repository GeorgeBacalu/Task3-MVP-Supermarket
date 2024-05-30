using Supermarket.Core.Dtos.Common;
using Supermarket.Core.ViewModels.Commands;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Receipts
{
    public class ReceiptDetailsVM : BaseVM
    {
        public ReceiptDto ReceiptDto { get; set; }

        public ICommand BackCommand { get; }

        public ReceiptDetailsVM(ReceiptDto receiptDto)
        {
            ReceiptDto = receiptDto;
            BackCommand = new RelayCommand(o => Back());
        }

        private void Back() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}