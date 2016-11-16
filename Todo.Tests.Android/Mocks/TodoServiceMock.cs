using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Contracts;
using Todo.Models;

namespace Todo.Tests.Android.Mocks
{
    internal class TodoServiceMock : ITodoService
    {
        public List<TodoItem> Items { get; } = new List<TodoItem>();

        public async Task<IEnumerable<TodoItem>> LoadItemsAsync()
        {
            return Items.AsEnumerable();
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var item = Items.First(i => i.Id == id);
            Items.Remove(item);
        }

        public async Task<TodoItem> InsertItemAsync(string newItemDescription)
        {
            var item = new TodoItem {Id = Guid.NewGuid(), Description = newItemDescription};
            Items.Add(item);
            return item;
        }
    }
}