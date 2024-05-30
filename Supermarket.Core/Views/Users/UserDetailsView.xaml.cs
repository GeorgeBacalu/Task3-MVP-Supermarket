using Supermarket.Core.ViewModels.Users;
using System.Windows;

namespace Supermarket.Core.Views.Users
{
    public partial class UserDetailsView : Window
    {
        public UserDetailsView(UserDetailsVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}