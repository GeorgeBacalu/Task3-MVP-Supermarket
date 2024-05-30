using Supermarket.Core.ViewModels.Users;
using System.Windows;

namespace Supermarket.Core.Views.Users
{
    public partial class UsersView : Window
    {
        public UsersView(UsersVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}