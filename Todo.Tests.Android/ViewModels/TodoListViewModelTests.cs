using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Todo.Models;
using Todo.Tests.Android.Mocks;
using Todo.ViewModels;

namespace Todo.Tests.Android.ViewModels
{
    [TestFixture]
    public class TodoListViewModelTests
    {
        private static TodoItem[] _items;
        private static TodoServiceMock _serviceMock;

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

            _serviceMock.Items.Should()
                .NotContain(i => i.Id == toDelete.Id);
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

            _serviceMock.Items.Should()
                .Contain(i => i.Description == description);
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

            _serviceMock = new TodoServiceMock();
            _serviceMock.Items.AddRange(_items);

            var vm = new TodoListViewModel(_serviceMock);
            await vm.Init();
            return vm;
        }
    }
}