using FluentAssertions;
using TechTalk.SpecFlow;
using UnifesoPoo.Pedido.Api.Tests.Drivers;

namespace UnifesoPoo.Pedido.Api.Tests.Steps
{
    [Binding]
    public sealed class SearchingStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SeleniumWebDriver _webDriver;

        public SearchingStepDefinitions(ScenarioContext scenarioContext, SeleniumWebDriver webDriver)
        {
            _scenarioContext = scenarioContext;
            _webDriver = webDriver;
        }

        [Given(@"I go to '(.*)'")]
        public void GivenIGoTo(string url)
        {
            _webDriver.GoTo(url);
        }

        [When(@"I search for the product '(.*)'")]
        public void WhenISearchForTheProduct(string productName)
        {
            var searchElement = _webDriver.FindElementById("input-busca");
            searchElement.SendKeys(productName);
            searchElement.Submit();
        }

        [Then(@"I see the breadcrumb with text '(.*)'")]
        public void ThenISeeTheBreadcrumbWithText(string productName)
        {
            var breadcrumb = _webDriver.FindElementById("listingBreadcrumbs");
            breadcrumb.Text.Should().Contain(productName);
        }

        [Then(@"I see the main with id '(.*)'")]
        public void ThenISeeTheMainWithId(string elementId)
        {
            var element = _webDriver.FindElementById(elementId);
            element.Should().NotBeNull();
        }
    }
}