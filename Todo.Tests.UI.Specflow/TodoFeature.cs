using NUnit.Framework;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace Todo.Tests.UI.Specflow
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public partial class TodoFeature
    {
        private readonly Platform _platform;
        private IApp _app;

        public TodoFeature(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
            FeatureContext.Current["App"] = _app;
        }

        [AfterStep]
        public void AfterEachStep()
        {
            _app.Screenshot(ScenarioContext.Current.StepContext.StepInfo.Text);
        }
    }
}