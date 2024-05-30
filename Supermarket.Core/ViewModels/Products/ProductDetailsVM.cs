using Supermarket.Core.Dtos.Common;
using Supermarket.Core.ViewModels.Commands;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Products
{
    public class ProductDetailsVM : BaseVM
    {
        public ProductDto ProductDto { get; set; }

        public ICommand BackCommand { get; }

        public ProductDetailsVM(ProductDto productDto)
        {
            ProductDto = productDto;
            BackCommand = new RelayCommand(o => Back());
        }

        private void Back() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}