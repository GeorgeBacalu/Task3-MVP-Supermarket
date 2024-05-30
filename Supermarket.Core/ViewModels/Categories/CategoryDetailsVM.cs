using Supermarket.Core.Dtos.Common;
using Supermarket.Core.ViewModels.Commands;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Categories
{
    public class CategoryDetailsVM : BaseVM
    {
        public CategoryDto CategoryDto { get; set; }

        public ICommand BackCommand { get; }

        public CategoryDetailsVM(CategoryDto categoryDto)
        {
            CategoryDto = categoryDto;
            BackCommand = new RelayCommand(o => Back());
        }

        private void Back() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}