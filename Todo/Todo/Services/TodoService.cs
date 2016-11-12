using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Contracts;
using Todo.Models;
using Todo.Pages;
using Todo.ViewModels;

namespace Todo.Services
{
    public class TodoService : ITodoService
    {
        private IList<TodoItem> _fakeDataBase;

        public async Task<IEnumerable<TodoItem>> LoadItemsAsync()
        {
            return _fakeDataBase = new List<TodoItem>
            {
                new TodoItem {Id = Guid.NewGuid(), Description = "Buy some Milk"},
                new TodoItem {Id = Guid.NewGuid(), Description = "Feed the cat"},
                new TodoItem {Id = Guid.NewGuid(), Description = "Delete me"}
            };
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var item = _fakeDataBase.First(i => i.Id == id);
            _fakeDataBase.Remove(item);
        }

        public async Task<TodoItem> InsertItemAsync(string newItemDescription)
        {
            var item = new TodoItem
            {
                Id = Guid.NewGuid(),
                Description = newItemDescription
            };

            _fakeDataBase.Add(item);
            
            return item;
        }
    }
}