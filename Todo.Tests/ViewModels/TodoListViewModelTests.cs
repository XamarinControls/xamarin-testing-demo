using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Todo.Contracts;
using Todo.Models;
using Todo.ViewModels;

namespace Todo.Tests.ViewModels
{
    [TestFixture]
    public class TodoListViewModelTests
    {
        private static TodoItem[] _items;
        private static Mock<ITodoService> _serviceMock;

        [Test]
        public async Task Init_should_load_items()
        {
            var vm = await CreateAndInitAsync();

            vm.Items.Should()
                .Contain(i => i.Id == _items[0].Id)
                .And
                .Contain(i => i.Id == _items[1].Id);
        }

        [Test]
        public async Task DeleteCommand_should_delete_item()
        {
            var vm = await CreateAndInitAsync();

            var toDelete = vm.Items.First();
            await toDelete.DeleteCommand.ExecuteAsync(toDelete);

            _serviceMock.Verify(m => m.DeleteItemAsync(toDelete.Id));
            vm.Items.Should()
                .NotContain(i => i.Id == toDelete.Id);
        }

        [Test]
        public async Task AddCommand_should_add_item()
        {
            var description = "Kaffee kochen";
            var vm = await CreateAndInitAsync();

            vm.NewItemDescription = description;
            await vm.AddCommand.ExecuteAsync();

            _serviceMock.Verify(m => m.InsertItemAsync(description));
            vm.Items.Should()
                .Contain(i => i.Description.Equals(description));
        }

        private static async Task<TodoListViewModel> CreateAndInitAsync()
        {
            _items = new[]
            {
                new TodoItem {Id = Guid.NewGuid(), Description = "Test"},
                new TodoItem {Id = Guid.NewGuid(), Description = "Test 2"}
            };

            _serviceMock = new Mock<ITodoService>();
            _serviceMock.Setup(m => m.LoadItemsAsync()).ReturnsAsync(_items);
            _serviceMock.Setup(m => m.InsertItemAsync(It.IsAny<string>()))
                .ReturnsAsync((string d) => new TodoItem {Id = Guid.NewGuid(), Description = d});

            var vm = new TodoListViewModel(_serviceMock.Object);
            await vm.Init();
            return vm;
        }
    }
}