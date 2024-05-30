using Supermarket.Core.ViewModels.Offers;
using System.Windows;

namespace Supermarket.Core.Views.Offers
{
    public partial class OffersView : Window
    {
        public OffersView(OffersVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}