using TechTalk.SpecFlow;
using UnifesoPoo.Pedido.Api.Tests.Drivers;

namespace UnifesoPoo.Pedido.Api.Tests.Hooks
{
    [Binding]
    public class BrowserHooks
    {
        private readonly SeleniumWebDriver _webDriver;

        public BrowserHooks(SeleniumWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [BeforeScenario("BrowserRequired")]
        public void BeforeScenario()
        {
            _webDriver.OpenBrowser();
        }

        [AfterScenario("BrowserRequired")]
        public void AfterScenario()
        {
            _webDriver.CloseBrowser();
        }
    }
}