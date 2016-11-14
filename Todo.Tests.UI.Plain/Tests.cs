using NUnit.Framework;
using Xamarin.UITest;

namespace Todo.Tests.UI.Plain
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        readonly Platform _platform;
        private IApp _app;

        public Tests(Platform platform)
        {
            this._platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public void AddTask()
        {
            var task = "Added Item";
            _app.Tap(q => q.Marked("AddButton"));
            _app.EnterText(q => q.Marked("AddEntry"), task);
            _app.Tap(_page.AddButton);
            _app.WaitForElement(_page.LabelOfTask(task));
        }
    }
}