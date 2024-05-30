using Supermarket.Core.ViewModels.Categories;
using System.Windows;

namespace Supermarket.Core.Views.Categories
{
    public partial class CategoryDetailsView : Window
    {
        public CategoryDetailsView(CategoryDetailsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}