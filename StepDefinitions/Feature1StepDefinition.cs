using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using log4net;
using log4net.Config;
using System.IO;
namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class Feature1StepDefinition
    {
        private readonly IWebDriver _driver;
        private static readonly ILog _logger = LogManager.GetLogger(typeof(Feature1StepDefinition));

        public Feature1StepDefinition(IWebDriver driver)
        {
            _driver = driver;

            // Initialize log4net from the config file
            var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }





        [Given(@"Browse  youtube URl")]
        public void GivenBrowseYoutubeURl()
        {

            _driver.Url = "http://www.google.com";
        }

        [When(@"search Testers talk")]
        public void WhenSearchTestersTalk()
        {

            try
            {
                Thread.Sleep(500);
                _driver.FindElement(By.Name("search_query")).SendKeys("Testing C#");
                Thread.Sleep(500);
                _driver.FindElement(By.Name("search_query")).SendKeys(Keys.Enter);
                Thread.Sleep(1000); // This will cause an exception
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Caught Exception: {ex.Message}");
                _logger.Error("An error occurred during search", ex);// Log the error with the exception object
                throw;
            }




        }

        [Then(@"quit the browser")]
        public void ThenQuitTheBrowser()
        {
            _driver.Quit();
        }



    }
}
