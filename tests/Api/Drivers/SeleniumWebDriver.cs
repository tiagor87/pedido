using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace UnifesoPoo.Pedido.Api.Tests.Drivers
{
    public class SeleniumWebDriver
    {
        private IWebDriver _driver;

        public SeleniumWebDriver()
        {
        }

        public void OpenBrowser()
        {
            _driver = new EdgeDriver();
        }

        public void GoTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElementById(string elementId)
        {
            return _driver.FindElement(By.Id(elementId));
        }

        public void CloseBrowser()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}