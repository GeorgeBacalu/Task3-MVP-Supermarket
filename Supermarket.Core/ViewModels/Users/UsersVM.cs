using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using Supermarket.Core.Views.Users;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Users
{
    public class UsersVM : BaseVM
    {
        private readonly IUserService _userService;
        public ObservableCollection<UserDto> UserDtos { get; set; }
        public string SearchKey { get; set; }
        public event Action OnClose;

        public ICommand AddUserCommand { get; }
        public ICommand UpdateUserCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand CloseCommand { get; }

        public UsersVM(IUserService userService)
        {
            _userService = userService;
            UserDtos = new ObservableCollection<UserDto>(_userService.GetAll());
            AddUserCommand = new RelayCommand(o => AddUser());
            UpdateUserCommand = new RelayCommand(o => UpdateUser(o as UserDto));
            DeleteUserCommand = new RelayCommand(o => DeleteUser(o as UserDto));
            ViewDetailsCommand = new RelayCommand(o => ViewDetails(o as UserDto));
            SearchCommand = new RelayCommand(o => GetByKey());
            CloseCommand = new RelayCommand(o => OnClose?.Invoke());
        }

        private void AddUser()
        {
            var saveUserView = new SaveUserView(new SaveUserVM(_userService));
            saveUserView.ShowDialog();
            RefreshUsers();
        }

        private void UpdateUser(UserDto userDto)
        {
            var saveUserView = new SaveUserView(new SaveUserVM(_userService, userDto));
            saveUserView.ShowDialog();
            RefreshUsers();
        }

        private void DeleteUser(UserDto userDto)
        {
            _userService.DeleteById(userDto.Id);
            RefreshUsers();
        }

        private void ViewDetails(UserDto userDto)
        {
            var userDetailsView = new UserDetailsView(new UserDetailsVM(userDto));
            userDetailsView.ShowDialog();
        }

        private void GetByKey()
        {
            UserDtos = new ObservableCollection<UserDto>(_userService.GetByKey(SearchKey));
            OnPropertyChanged(nameof(UserDtos));
        }

        private void RefreshUsers()
        {
            UserDtos = new ObservableCollection<UserDto>(_userService.GetAll());
            OnPropertyChanged(nameof(UserDtos));
        }
    }
}