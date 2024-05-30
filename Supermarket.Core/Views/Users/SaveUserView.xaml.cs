using Supermarket.Core.ViewModels.Users;
using System.Windows;

namespace Supermarket.Core.Views.Users
{
    public partial class SaveUserView : Window
    {
        public SaveUserView(SaveUserVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}