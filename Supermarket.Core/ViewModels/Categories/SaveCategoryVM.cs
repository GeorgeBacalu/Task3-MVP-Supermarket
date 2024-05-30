using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace Supermarket.Core.ViewModels.Categories
{
    public class SaveCategoryVM : BaseVM
    {
        private readonly ICategoryService _categoryService;
        public CategoryDto CategoryDto { get; set; }
        public string Title { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public SaveCategoryVM(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            CategoryDto = new CategoryDto();
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Add Category";
        }

        public SaveCategoryVM(ICategoryService categoryService, CategoryDto categoryDto)
        {
            _categoryService = categoryService;
            CategoryDto = categoryDto;
            SaveCommand = new RelayCommand(o => Save());
            CancelCommand = new RelayCommand(o => Cancel());
            Title = "Update Category";
        }

        private void Save()
        {
            if (CategoryDto.Id == Guid.Empty)
                _categoryService.Add(CategoryDto);
            else
                _categoryService.UpdateById(CategoryDto, CategoryDto.Id);
            Cancel();
        }

        private void Cancel() => Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
    }
}