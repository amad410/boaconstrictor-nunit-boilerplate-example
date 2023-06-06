using Boa.Constrictor.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screenplay_Nunit_Boilerplate.Views
{
    public static class ArticlePage
    {
        public static IWebLocator Title => L(
           "Title",
           By.CssSelector("[id='firstHeading'] span"));


        private static IWebLocator L(string v, By by)
        {
            return new WebLocator(v, by);
        }
    }
}
