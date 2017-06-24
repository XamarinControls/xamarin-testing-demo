using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Todo.Contracts;
using Todo.Models;

namespace Todo.ViewModels
{
    public class TodoListViewModel
        : MvxViewModel
    {
        private readonly ITodoService _service;
        private readonly MvxAsyncCommand<TodoItemViewModel> _deleteItemCommand;
        private string _newItemDescription;

        public MvxObservableCollection<TodoItemViewModel> Items { get; }
        public string Title { get; } = "Todo";

        public string NewItemDescription
        {
            get { return _newItemDescription; }
            set { SetProperty(ref _newItemDescription, value); }
        }

        public MvxAsyncCommand AddCommand { get; }

        public TodoListViewModel(ITodoService service)
        {
            _service = service;
            _deleteItemCommand = new MvxAsyncCommand<TodoItemViewModel>(DeleteItemAsync);
            Items = new MvxObservableCollection<TodoItemViewModel>();
            AddCommand = new MvxAsyncCommand(AddItemAsync);
        }

        public async Task Init()
        {
            await LoadItems();
        }

        private async Task LoadItems()
        {
            try
            {
                var items = await _service.LoadItemsAsync();
                var vms = items.Select(CreateTotoItemViewModel);
                Items.Clear();
                Items.AddRange(vms);
            }
            catch (Exception ex)
            {
                // ..
            }
        }

        private async Task DeleteItemAsync(TodoItemViewModel item)
        {
            try
            {
                await _service.DeleteItemAsync(item.Id);
                Items.Remove(item);
            }
            catch (Exception ex)
            {
                // ..
            }
        }

        private async Task AddItemAsync()
        {
            try
            {
                var item = await _service.InsertItemAsync(NewItemDescription);
                Items.Add(CreateTotoItemViewModel(item));
                NewItemDescription = "";
            }
            catch (Exception ex)
            {
                // ..
            }
        }

        private TodoItemViewModel CreateTotoItemViewModel(TodoItem i)
        {
            return new TodoItemViewModel(i, _deleteItemCommand);
        }
    }
}