using MvvmCross.Forms.Presenter.Core;
using Todo.ViewModels;
using Xamarin.Forms;

namespace Todo.Pages
{
    public partial class TodoListPage : MvxContentPage<TodoListViewModel>
    {
        public TodoListPage()
        {
            InitializeComponent();
        }
    }
}
