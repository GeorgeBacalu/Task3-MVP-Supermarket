using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Dtos.Request;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Users
{
    public class SaveUserVM : BaseVM
    {
        private readonly IUserService _userService;
        public UserDto UserDto { get; set; }
        public string Title { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public SaveUserVM(IUserService userService)
        {
            _userService = userService;
            UserDto = new UserDto();
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Add User";
        }

        public SaveUserVM(IUserService userService, UserDto userDto)
        {
            _userService = userService;
            UserDto = userDto;
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Update User";
        }

        private void Save()
        {
            if (UserDto.Id == Guid.Empty) 
                _userService.Register(new RegisterRequest { Name = UserDto.Name, Email = UserDto.Email, Password = "Password", RoleId = UserDto.RoleId });
            else 
                _userService.UpdateById(UserDto, UserDto.Id);
            Cancel();
        }

        private void Cancel() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}