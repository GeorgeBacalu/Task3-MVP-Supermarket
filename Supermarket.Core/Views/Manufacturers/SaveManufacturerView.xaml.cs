using System.Windows;
using Supermarket.Core.ViewModels.Manufacturers;

namespace Supermarket.Core.Views.Manufacturers
{
    public partial class SaveManufacturerView : Window
    {
        public SaveManufacturerView(SaveManufacturerVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}