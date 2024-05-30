using Supermarket.Core.ViewModels.Categories;
using System.Windows;

namespace Supermarket.Core.Views.Categories
{
    public partial class SaveCategoryView : Window
    {
        public SaveCategoryView(SaveCategoryVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}