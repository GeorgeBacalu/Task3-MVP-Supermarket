using Supermarket.Core.ViewModels.Products;
using System.Windows;

namespace Supermarket.Core.Views.Products
{
    public partial class ProductDetailsView : Window
    {
        public ProductDetailsView(ProductDetailsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}