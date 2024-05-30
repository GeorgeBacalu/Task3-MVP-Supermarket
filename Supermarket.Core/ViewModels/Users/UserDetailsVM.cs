using Supermarket.Core.Dtos.Common;
using System.Windows;
using System.Windows.Input;
using Supermarket.Core.ViewModels.Commands;

namespace Supermarket.Core.ViewModels.Users
{
    public class UserDetailsVM : BaseVM
    {
        public UserDto UserDto { get; set; }

        public ICommand BackCommand { get; }

        public UserDetailsVM(UserDto userDto)
        {
            UserDto = userDto;
            BackCommand = new RelayCommand(o => Back());
        }

        private void Back() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}