using Supermarket.Core.ViewModels.Manufacturers;
using System.Windows;

namespace Supermarket.Core.Views.Manufacturers
{
    public partial class ManufacturersView : Window
    {
        public ManufacturersView(ManufacturersVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}