using System;
using Xamarin.UITest.Queries;

namespace Todo.Tests.UI.PageObjects
{
    public class TodoPage
    {
        public Func<AppQuery, AppQuery> AddButton => q => q.Marked("AddButton");
        public Func<AppQuery, AppQuery> AddEntry => q => q.Marked("AddEntry");
        public Func<AppQuery, AppQuery> Tasks => q => q.Class("ViewCellRenderer_ViewCellContainer");

        public Func<AppQuery, AppQuery> DeleteButtonOfTask(string task)
        {
            return q => TaskLabel(task)(q).Parent(2).Descendant().Marked("DeleteButton");
        }

        public Func<AppQuery, AppQuery> TaskLabel(string task)
        {
            return q => Tasks(q).Descendant().Text(task);
        }
    }
}