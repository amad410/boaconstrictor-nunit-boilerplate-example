
using Boa.Constrictor.Selenium;
using OpenQA.Selenium;

namespace Screenplay_Nunit_Boilerplate.Views
{
    public static class MainPage
    {

        public const string Url = "https://en.wikipedia.org/wiki/Main_Page";

        public static IWebLocator SearchInput => L(
            "Wikipedia Search Input",
            By.Name("search"));

        private static IWebLocator L(string v, By by)
        {
            return new WebLocator(v, by);
        }

        public static IWebLocator SearchBtn => L(
            "Wikipedia Search Button",
            By.XPath("//button[text()='Search']"));


    }
}
