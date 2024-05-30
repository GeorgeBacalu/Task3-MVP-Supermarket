using Supermarket.Core.ViewModels.Receipts;
using System.Windows;

namespace Supermarket.Core.Views.Receipts
{
    public partial class SaveReceiptView : Window
    {
        public SaveReceiptView(SaveReceiptVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}