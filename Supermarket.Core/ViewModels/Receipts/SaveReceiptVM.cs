using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using System.Collections.ObjectModel;
using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;

namespace Supermarket.Core.ViewModels.Receipts
{
    public class SaveReceiptVM : BaseVM
    {
        private readonly IReceiptService _receiptService;
        private readonly IUserService _userService;

        public ReceiptDto ReceiptDto { get; set; }
        public string Title { get; set; }

        public ObservableCollection<UserDto> Users { get; set; }

        private UserDto selectedUser;
        public UserDto SelectedUser { get => selectedUser; set { selectedUser = value; ReceiptDto.IssuerId = value?.Id ?? Guid.Empty; OnPropertyChanged(nameof(SelectedUser)); } }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public SaveReceiptVM(IReceiptService receiptService, IUserService userService)
        {
            _receiptService = receiptService;
            _userService = userService;
            ReceiptDto = new ReceiptDto();
            Users = new ObservableCollection<UserDto>(_userService.GetAll());
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Add Receipt";
        }

        public SaveReceiptVM(IReceiptService receiptService, IUserService userService, ReceiptDto receiptDto)
        {
            _receiptService = receiptService;
            _userService = userService;
            ReceiptDto = receiptDto;
            Users = new ObservableCollection<UserDto>(_userService.GetAll());
            SelectedUser = Users.FirstOrDefault(user => user.Id == ReceiptDto.IssuerId);
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Update Receipt";
        }

        private void Save()
        {
            if (ReceiptDto.Id == Guid.Empty)
                _receiptService.Add(ReceiptDto);
            else
                _receiptService.UpdateById(ReceiptDto, ReceiptDto.Id);
            Cancel();
        }

        private void Cancel() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}