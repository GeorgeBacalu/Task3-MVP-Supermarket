using Supermarket.Core.ViewModels;
using System.Windows;

namespace Supermarket.Core.Views.Auth
{
    public partial class LoginView : Window
    {
        public LoginView(AuthVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}