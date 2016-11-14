using NUnit.Framework;
using Todo.Tests.UI.PageObjects;
using Xamarin.UITest;

namespace Todo.Tests.UI.PageObject
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        private TodoPage _page;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);

            _page = new TodoPage();
        }

        [Test]
        public void AddTask()
        {
            var task = "Added Item";
            app.Tap(_page.AddEntry);
            app.EnterText(_page.AddEntry, task);
            app.Tap(_page.AddButton);
            app.WaitForElement(_page.TaskLabel(task));
        }

        [Test]
        public void DeleteTask()
        {
            var task = "Delete me";
            app.Tap(_page.DeleteButtonOfTask(task));

            app.WaitForNoElement(_page.TaskLabel(task));
        }

        [Test]
        public void Repl()
        {
            app.Repl();
        }
    }
}