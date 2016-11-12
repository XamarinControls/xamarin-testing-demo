using System;
using MvvmCross.Core.ViewModels;
using Todo.Models;

namespace Todo.ViewModels
{
    public class TodoItemViewModel : MvxNotifyPropertyChanged
    {
        private string _description;

        public Guid Id { get; }

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public MvxAsyncCommand<TodoItemViewModel> DeleteCommand { get; }

        public TodoItemViewModel(TodoItem item, MvxAsyncCommand<TodoItemViewModel> deleteCommand)
        {
            Id = item.Id;
            DeleteCommand = deleteCommand;
            Description = item.Description;
        }
    }
}