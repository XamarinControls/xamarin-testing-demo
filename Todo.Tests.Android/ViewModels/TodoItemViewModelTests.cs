using System;
using System.Threading.Tasks;
using FluentAssertions;
using MvvmCross.Core.ViewModels;
using NUnit.Framework;
using Todo.Models;
using Todo.ViewModels;

namespace Todo.Tests.Android.ViewModels
{
    [TestFixture]
    public class TodoItemViewModelTests
    {
        [Test]
        public void ctor_should_set_properties()
        {
            var item = new TodoItem {Id = Guid.NewGuid(), Description = "Foo"};
            var command = new MvxAsyncCommand<TodoItemViewModel>(i => Task.FromResult(0));
            var vm = new TodoItemViewModel(item, command);

            vm.Id.Should().Be(item.Id);
            vm.Description.Should().Be(item.Description);
            vm.DeleteCommand.Should().Be(command);
        }
    }
}