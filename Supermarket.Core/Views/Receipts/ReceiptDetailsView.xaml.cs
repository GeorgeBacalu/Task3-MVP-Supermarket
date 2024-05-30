using Supermarket.Core.ViewModels.Receipts;
using System.Windows;

namespace Supermarket.Core.Views.Receipts
{
    public partial class ReceiptDetailsView : Window
    {
        public ReceiptDetailsView(ReceiptDetailsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}