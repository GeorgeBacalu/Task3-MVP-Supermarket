using Supermarket.Core.ViewModels;
using System.Windows;

namespace Supermarket.Core.Views.Auth
{
    public partial class RegisterView : Window
    {
        public RegisterView(MainVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.OnClose += () => Close();
        }
    }
}