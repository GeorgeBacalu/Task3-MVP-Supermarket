using Supermarket.Core.ViewModels.Offers;
using System.Windows;

namespace Supermarket.Core.Views.Offers
{
    public partial class SaveOfferView : Window
    {
        public SaveOfferView(SaveOfferVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}