using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class DataDrivenStepDefinition2
    {
        private IWebDriver driver;
        public DataDrivenStepDefinition2(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then(@"search with (.*)")]
        public void ThenSearchWithTestersTalk(string searchKey)
        {
            Thread.Sleep(500);
            driver.FindElement(By.Name("search_query")).SendKeys(searchKey);
            Thread.Sleep(500);
            driver.FindElement(By.Name("search_query")).SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }



    }
}
