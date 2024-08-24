using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class DataDrivenStepDefinition
    {
        private IWebDriver driver;
        public DataDrivenStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then(@"search ""([^""]*)""")]
        public void ThenSearch(string selenium)
        {
            Thread.Sleep(500);
            driver.FindElement(By.Name("search_query")).SendKeys(selenium);
            Thread.Sleep(500);
            driver.FindElement(By.Name("search_query")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }



    }
}
