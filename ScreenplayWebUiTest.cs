using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Selenium;
using FluentAssertions;
using OpenQA.Selenium.Chrome;
using Screenplay_Nunit_Boilerplate.Flows;
using Screenplay_Nunit_Boilerplate.Views;

namespace Screenplay_Nunit_Boilerplate
{
    public class ScreenplayWebUiTest
    {
        IActor? actor = null;


        [SetUp]
        public void Setup()
        {
            actor = new Actor(name: "John Doe", logger: new ConsoleLogger());
            actor.Can(BrowseTheWeb.With(new ChromeDriver()));


        }

        [TearDown]
        public void Teardown()
        {
            actor.AttemptsTo(QuitWebDriver.ForBrowser());
        }
        [Test]
        public void TestNavigationToWikipedia()
        {

            actor.AttemptsTo(Navigate.ToUrl(MainPage.Url));
            string text = actor.AsksFor(ValueAttribute.Of(MainPage.SearchInput));
            text.Should().BeEmpty();


        }

        [Test]
        public void TestWikipediaSearch()
        {
            
            actor.AttemptsTo(Navigate.ToUrl(MainPage.Url));
            actor.AttemptsTo(SendKeys.To(MainPage.SearchInput, "Michael Jordan"));
            actor.AttemptsTo(Click.On(MainPage.SearchBtn));
            actor.AttemptsTo(Wait.Until(Text.Of(ArticlePage.Title), IsEqualTo.Value("Michael Jordan")));
            //actor.WaitsUntil(Text.Of(ArticlePage.Title), IsEqualTo.Value("Michael Jordan"));

        }

        [Test]
        public void SearchWikipediaFlow()
        {
            actor.AttemptsTo(Navigate.ToUrl(MainPage.Url));
            actor.AttemptsTo(SearchWikipedia.For("Michael Jordan"));

        }



    }
}