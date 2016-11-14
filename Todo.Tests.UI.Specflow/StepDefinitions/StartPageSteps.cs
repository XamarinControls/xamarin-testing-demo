using TechTalk.SpecFlow;
using Todo.Tests.UI.PageObjects;
using Xamarin.UITest;

namespace Todo.Tests.UI.Specflow.StepDefinitions
{
    [Binding]
    public sealed class TodoPageSteps
    {
        private TodoPage _page;
        private IApp _app;

        public TodoPageSteps()
        {
            _page = new TodoPage();
            _app = FeatureContext.Current.Get<IApp>("App");
        }

        [When(@"I enter ""(.*)""")]
        public void WhenIEnter(string task)
        {
            _app.Tap(_page.AddEntry);
            _app.EnterText(_page.AddEntry, task);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _app.Tap(_page.AddButton);
        }

        [Then(@"the task ""(.*)"" should be added to the list")]
        public void ThenTheTaskShouldBeAddedToTheList(string task)
        {
            _app.WaitForElement(_page.TaskLabel(task));
        }

        [When(@"I delete the ""(.*)"" task")]
        public void WhenIDeleteTheTask(string task)
        {
            _app.Tap(_page.DeleteButtonOfTask(task));
        }

        [Then(@"the task ""(.*)"" should be removed from the list")]
        public void ThenTheTaskShouldBeRemovedFromTheList(string task)
        {
            _app.WaitForNoElement(_page.TaskLabel(task));
        }
    }
}
