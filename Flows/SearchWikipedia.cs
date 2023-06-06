using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Selenium;
using Screenplay_Nunit_Boilerplate.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screenplay_Nunit_Boilerplate.Flows
{
    public class SearchWikipedia : ITask
    {
        public string Phrase { get; }

        private SearchWikipedia(string phrase) => Phrase = phrase;

        public static SearchWikipedia For(string phrase) => new SearchWikipedia(phrase);
        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(SendKeys.To(MainPage.SearchInput, Phrase));
            actor.AttemptsTo(Click.On(MainPage.SearchBtn));
        }
    }
}
