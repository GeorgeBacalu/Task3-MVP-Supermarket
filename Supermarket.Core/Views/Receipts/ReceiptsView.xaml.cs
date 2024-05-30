using Supermarket.Core.ViewModels.Receipts;
using System.Windows;

namespace Supermarket.Core.Views.Receipts
{
    public partial class ReceiptsView : Window
    {
        public ReceiptsView(ReceiptsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}