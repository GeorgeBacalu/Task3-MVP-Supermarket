using System.Windows;
using Supermarket.Core.ViewModels.Manufacturers;

namespace Supermarket.Core.Views.Manufacturers
{
    public partial class ManufacturerDetailsView : Window
    {
        public ManufacturerDetailsView(ManufacturerDetailsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}