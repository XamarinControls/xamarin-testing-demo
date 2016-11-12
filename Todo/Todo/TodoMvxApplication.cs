using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using Todo.ViewModels;

namespace Todo
{
    public class TodoMvxApplication : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<TodoListViewModel>();
        }
    }
}
