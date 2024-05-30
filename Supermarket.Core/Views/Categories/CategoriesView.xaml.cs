using System.Windows;
using Supermarket.Core.ViewModels.Categories;

namespace Supermarket.Core.Views.Categories
{
    public partial class CategoriesView : Window
    {
        public CategoriesView(CategoriesVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}