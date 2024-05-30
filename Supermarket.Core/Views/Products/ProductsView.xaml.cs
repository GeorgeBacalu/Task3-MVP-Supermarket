using Supermarket.Core.ViewModels.Products;
using System.Windows;

namespace Supermarket.Core.Views.Products
{
    public partial class ProductsView : Window
    {
        public ProductsView(ProductsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}