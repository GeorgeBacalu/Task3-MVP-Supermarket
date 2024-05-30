using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Services.Interfaces;
using Supermarket.Core.ViewModels.Commands;
using Supermarket.Core.Views.Categories;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace Supermarket.Core.ViewModels.Categories
{
    public class CategoriesVM : BaseVM
    {
        private readonly ICategoryService _categoryService;
        public ObservableCollection<CategoryDto> CategoryDtos { get; set; }
        public string SearchKey { get; set; }
        public event Action OnClose;

        public ICommand AddCategoryCommand { get; }
        public ICommand UpdateCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }
        public ICommand ViewDetailsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand CloseCommand { get; }

        public CategoriesVM(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            CategoryDtos = new ObservableCollection<CategoryDto>(_categoryService.GetAll());
            AddCategoryCommand = new RelayCommand(o => AddCategory());
            UpdateCategoryCommand = new RelayCommand(o => UpdateCategory(o as CategoryDto));
            DeleteCategoryCommand = new RelayCommand(o => DeleteCategory(o as CategoryDto));
            ViewDetailsCommand = new RelayCommand(o => ViewDetails(o as CategoryDto));
            SearchCommand = new RelayCommand(o => GetByKey());
            CloseCommand = new RelayCommand(o => OnClose?.Invoke());
        }

        private void AddCategory()
        {
            var saveCategoryView = new SaveCategoryView(new SaveCategoryVM(_categoryService));
            saveCategoryView.ShowDialog();
            RefreshCategories();
        }

        private void UpdateCategory(CategoryDto categoryDto)
        {
            var saveCategoryView = new SaveCategoryView(new SaveCategoryVM(_categoryService, categoryDto));
            saveCategoryView.ShowDialog();
            RefreshCategories();
        }

        private void DeleteCategory(CategoryDto categoryDto)
        {
            _categoryService.DeleteById(categoryDto.Id);
            RefreshCategories();
        }

        private void ViewDetails(CategoryDto categoryDto)
        {
            var categoryDetailsView = new CategoryDetailsView(new CategoryDetailsVM(categoryDto));
            categoryDetailsView.ShowDialog();
        }

        private void GetByKey()
        {
            CategoryDtos = new ObservableCollection<CategoryDto>(_categoryService.GetByKey(SearchKey));
            OnPropertyChanged(nameof(CategoryDtos));
        }

        private void RefreshCategories()
        {
            CategoryDtos = new ObservableCollection<CategoryDto>(_categoryService.GetAll());
            OnPropertyChanged(nameof(CategoryDtos));
        }
    }
}