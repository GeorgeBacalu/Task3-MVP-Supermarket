using Supermarket.Core.ViewModels.Offers;
using System.Windows;

namespace Supermarket.Core.Views.Offers
{
    public partial class OfferDetailsView : Window
    {
        public OfferDetailsView(OfferDetailsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}