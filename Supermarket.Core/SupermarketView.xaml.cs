using Supermarket.Core.ViewModels;
using System.Windows;

namespace Supermarket.Core
{
    public partial class SupermarketView : Window
    {
        public SupermarketView() => InitializeComponent();

        public SupermarketView(AuthVM viewModel) : this()
        {
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}