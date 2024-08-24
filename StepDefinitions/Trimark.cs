using ExcelDataReader;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V119.Debugger;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.Pages;
using System.Text;
using System.Xml.Linq;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class Trimark
    {
        private IWebDriver driver;
        LoginPage loginPage;
        ManageCompanies managecompanies;
        Sites sitepage;
        Devices devicepage;
        Points pointspage;
        Points pointspage1;
        HistoricalTrends historicalTrends;

        public Trimark(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Browse the New Staging URL")]
        public void GivenBrowseTheNewStagingURL()
        {
            driver.Url = "http://10.3.4.7/";
            Thread.Sleep(4000);

        }

        [Given(@"Login to the New Staging")]
        public void GivenLoginToTheNewStaging()
        {
            loginPage = new LoginPage(driver);
            managecompanies = loginPage.Login();
        }

        [Given(@"Navigate to the Sites page")]
        public void GivenNavigateToTheSitesPage()
        {
           managecompanies = new ManageCompanies(driver);
           sitepage = managecompanies.traverse();

        }


        [Given(@"Navigate to the Devices page")]
        public void GivenNavigateToTheDevicesPage()
        {
            driver.Url = "http://10.3.4.7/admin/devices?companyId=4&siteId=1000";


        }

        [When(@"Add a Device")]
        public void WhenAddADevice()
        {
            devicepage = new Devices(driver);
            devicepage.addaDevice();
        }


        [Given(@"Navigate to the Points page")]
        public void GivenNavigateToThePointsPage()
        {
            driver.Url = "http://10.3.4.7/admin/sitePoints?companyId=4&siteId=1000";

            /*IWebElement dropdownElement2 = driver.FindElement(By.CssSelector("#dropdownSysAdminMenu > i"));
            SelectElement select = new SelectElement(dropdownElement2);
            string valueToClick = "Current Site";
            select.SelectByText(valueToClick);*/
            Thread.Sleep(5000);

            
        }

        [When(@"Add a Derived Point")]
        public void WhenAddADerivedPoint()
        {
            pointspage = new Points(driver);
            pointspage.addapoint();
        }

        [When(@"Search the point")]
        public void WhenSearchThePoint()
        {

            pointspage1 = new Points(driver);
            pointspage1.searchapoint();

            /*string searchText = "1112024112630PMTBD_16_11_2023123";
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"MainContent_Site Point List35\"]/div[1]/div[3]/div/ul/li[3]/span"));
            element.Click();
            


                bool isTextPresent = IsTextPresent(driver, searchText);

            if (isTextPresent)
            {
                Console.WriteLine($"Text '{searchText}' is present on the page.");

                return;
            }
                

           
            int A = 2;
            do
            {

                IWebElement element1 = driver.FindElement(By.LinkText($"{A}"));

                element1.Click();
                Thread.Sleep(4000);

                string pageSource = driver.PageSource;
                if (pageSource.Contains(searchText))
                {
                    Console.WriteLine("Point Found");
                    break;
                }
                else
                    A = A + 1;

            } while (A < A+1); */

        }

        static bool IsTextPresent(IWebDriver driver, string searchText)
        {
            try
            {
                // Use XPath to locate elements containing the specified text
                IWebElement element = driver.FindElement(By.XPath($"//*[contains(text(), '{searchText}')]"));
                return element != null && element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        [Given(@"Navigate to the Portfolio Historical Trend Page")]
        public void GivenNavigateToThePortfolioHistoricalTrendPage()
        {
            IWebElement elementAS = driver.FindElement(By.LinkText("Advantage Solar"));
            elementAS.Click();
            Thread.Sleep(2000);
            IWebElement dropdown = driver.FindElement(By.XPath("//*[@id=\"linktrending\"]/span[2]"));
            dropdown.Click();
            Thread.Sleep(2000);
            IWebElement PHT = driver.FindElement(By.XPath("//*[@id=\"liHistorical Trend\"]/a"));
            
            PHT.Click();
            Thread.Sleep(1000);
            // Create a SelectElement object
           /* SelectElement select = new SelectElement(dropdown)

            // Select an option by visible text
            string optionText = "Portfolio Historical Trend";
            select.SelectByText(optionText);*/

            
        }

        [Given(@"Add points to the Page")]
        public void GivenAddPointsToThePage()
        {
            historicalTrends = new HistoricalTrends(driver);
            historicalTrends.AddPointstoHistoricalTrend();

            /*IWebElement elementHTP = driver.FindElement(By.XPath("//span[@class='glyphicon glyphicon-plus']"));
            elementHTP.Click();
            Thread.Sleep(20000);
            IWebElement elementPoint = driver.FindElement(By.XPath("//*[@id=\"d_4_anchor\"]/i[1]"));
            elementPoint.Click();
            IWebElement SubmitButton = driver.FindElement(By.Id("submitButton"));
            SubmitButton.Click();
            Thread.Sleep(2000);
            IWebElement Save = driver.FindElement(By.LinkText("Save"));
            Save.Click();
            Thread.Sleep(2000);
            string excelFilePath = "D:\\Trimark\\Portfolio Historical Trend Page\\SpecFlowProject1\\Excel\\Data.xlsx";
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read);
            //IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream, new ExcelReaderConfiguration { FallbackEncoding = encoding });
            reader.Read();
            string reportname = reader.GetValue(0)?.ToString();
            string groupname = reader.GetValue(1)?.ToString();
            IWebElement txtReportName = driver.FindElement(By.Id("txtReportName"));
            txtReportName.SendKeys(reportname);
            IWebElement txtGroupName = driver.FindElement(By.Id("txtGroupName"));
            txtGroupName.SendKeys(groupname);
            IWebElement okButton = driver.FindElement(By.Id("okButton"));
            okButton.Click();
            Thread.Sleep(5000); */
        }




        [Then(@"Quit the browser")]
        public void ThenQuitTheBrowser()
        {
            driver.Quit();
        }


    }
}
