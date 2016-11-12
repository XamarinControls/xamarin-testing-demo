using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Models;
using Todo.Pages;
using Todo.ViewModels;

namespace Todo.Contracts
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> LoadItemsAsync();
        Task DeleteItemAsync(Guid id);
        Task<TodoItem> InsertItemAsync(string newItemDescription);
    }
}