using NUnit.Framework;
using Todo.Tests.UI.PageObjects;
using Xamarin.UITest;

namespace Todo.Tests.UI.PageObject
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        private readonly Platform _platform;
        private IApp _app;
        private TodoPage _page;

        public Tests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
            _page = new TodoPage();
        }

        [Test]
        public void AddTask()
        {
            var task = "Added Item";
            _app.Tap(_page.AddEntry);
            _app.EnterText(_page.AddEntry, task);
            _app.Tap(_page.AddButton);
            _app.WaitForElement(_page.LabelOfTask(task));
        }

        [Test]
        public void DeleteTask()
        {
            var task = "Delete me";
            _app.Tap(_page.DeleteButtonOfTask(task));

            _app.WaitForNoElement(_page.LabelOfTask(task));
        }

        [Test]
        public void Repl()
        {
            _app.Repl();
        }
    }
}