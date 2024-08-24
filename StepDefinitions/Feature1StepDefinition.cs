using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class Feature1StepDefinition
    {
        private IWebDriver driver;
        public Feature1StepDefinition(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"Open the Chrome browser")]
        public void GivenOpenTheChromeBrowser()
        {

            //driver = new ChromeDriver();
        }

        [When(@"Browse the url")]
        public void WhenBrowseTheUrl()
        {
            
            driver.Url = "https://www.youtube.com/";
        }

        [Then(@"search Selenium")]
        public void ThenSearchSelenium()
        {
            Thread.Sleep(500);
            driver.FindElement(By.Name("search_query")).SendKeys("Testing C#");
            Thread.Sleep(500);
            driver.FindElement(By.Name("search_query")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            //driver.Quit();
        }

        /*[Given(@"Open the Chrome browserrr")]
        public void GivenOpenTheChromeBrowserrr()
        {
            driver = new ChromeDriver();
        }

        [When(@"Browse the urlll")]
        public void WhenBrowseTheUrlll()
        {
            driver.Url = "https://www.google.com/";
        }

        [Then(@"search Seleniummm")]
        public void ThenSearchSeleniummm()
        {
            Thread.Sleep(500);
            driver.FindElement(By.Id("APjFqb")).SendKeys("Testing C#");
            Thread.Sleep(500);
            driver.FindElement(By.Id("APjFqb")).SendKeys(Keys.Enter);
            Thread.Sleep(1000);
            driver.Quit();
        } */


    }
}
