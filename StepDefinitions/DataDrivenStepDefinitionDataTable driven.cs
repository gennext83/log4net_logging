using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class DataDrivenStepDefinitionDataTableDriven
    {
        private IWebDriver driver;
        public DataDrivenStepDefinitionDataTableDriven(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Then(@"Enter searck keyword in  youtube")]
        public void ThenEnterSearckKeywordInYoutube(Table table)
        {
            var searchCriteria = table.CreateSet<SearchKeyTestData>();

            foreach (var keyword in searchCriteria)
            {
                driver.FindElement(By.XPath("//*[@name='search_query']")).Clear();
                driver.FindElement(By.XPath("//*[@name='search_query']")).SendKeys(keyword.searchKey);
                driver.FindElement(By.XPath("//*[@name='search_query']")).SendKeys(Keys.Enter);
                Thread.Sleep(5000);
            }
        }

        public class SearchKeyTestData
        {
            public string searchKey { get; set; }
        }


    }
}
