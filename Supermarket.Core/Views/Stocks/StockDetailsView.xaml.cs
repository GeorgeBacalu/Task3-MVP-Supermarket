using Supermarket.Core.ViewModels.Stocks;
using System.Windows;

namespace Supermarket.Core.Views.Stocks
{
    public partial class StockDetailsView : Window
    {
        public StockDetailsView(StockDetailsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}