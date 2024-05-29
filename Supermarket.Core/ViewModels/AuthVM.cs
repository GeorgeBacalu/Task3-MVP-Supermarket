using Supermarket.Core.ViewModels.Commands;
using Supermarket.Core.Dtos.Request;
using Supermarket.Core.Services.Interfaces;
using System.Windows.Input;
using Supermarket.Core.Views.Auth;
using System;

namespace Supermarket.Core.ViewModels
{
    public class AuthVM : BaseVM
    {
        private readonly IUserService _userService;
        public ICommand RegisterCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand AccessRegisterCommand { get; }
        public ICommand AccessLoginCommand { get; }
        public event Action OnClose;

        private RegisterRequest _registerPayload;
        public RegisterRequest registerPayload { get => _registerPayload; set { _registerPayload = value; OnPropertyChanged(nameof(registerPayload)); } }

        private LoginRequest _loginPayload;
        public LoginRequest loginPayload { get => _loginPayload; set { _loginPayload = value; OnPropertyChanged(nameof(loginPayload)); } }

        public AuthVM(IUserService userService)
        {
            _userService = userService;
            RegisterCommand = new RelayCommand(o => Register());
            LoginCommand = new RelayCommand(o => Login());
            AccessRegisterCommand = new RelayCommand(o => AccessRegister());
            AccessLoginCommand = new RelayCommand(o => AccessLogin());
            registerPayload = new RegisterRequest();
            loginPayload = new LoginRequest();
        }

        private void AccessRegister() => new RegisterView(this).Show();

        private void AccessLogin() => new LoginView(this).Show();

        private void Register()
        {
            _userService.Register(registerPayload);
            ShowSupermarketView();
            OnClose?.Invoke();
        }

        private void Login()
        {
            _userService.Login(loginPayload);
            ShowSupermarketView();
            OnClose?.Invoke();
        }

        private void ShowSupermarketView()
        {
            var supermarketView = new SupermarketView();
            supermarketView.DataContext = this;
            supermarketView.Show();
        }
    }
}