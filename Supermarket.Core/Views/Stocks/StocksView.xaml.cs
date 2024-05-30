using Supermarket.Core.ViewModels.Stocks;
using System.Windows;

namespace Supermarket.Core.Views.Stocks
{
    public partial class StocksView : Window
    {
        public StocksView(StocksVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}