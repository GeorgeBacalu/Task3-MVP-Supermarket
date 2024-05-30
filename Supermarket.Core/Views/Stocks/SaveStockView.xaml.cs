using Supermarket.Core.ViewModels.Stocks;
using System.Windows;

namespace Supermarket.Core.Views.Stocks
{
    public partial class SaveStockView : Window
    {
        public SaveStockView(SaveStockVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}