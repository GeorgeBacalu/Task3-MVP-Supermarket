using Supermarket.Core.ViewModels.Products;
using System.Windows;

namespace Supermarket.Core.Views.Products
{
    public partial class SaveProductView : Window
    {
        public SaveProductView(SaveProductVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}