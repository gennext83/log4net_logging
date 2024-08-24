using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class Points
    {
        private IWebDriver driver;
        public Points(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void addapoint()
        {
            driver.FindElement(By.LinkText("Add Derived Point")).Click();
            Thread.Sleep(3000);

            /*string mainWindowHandle = driver.CurrentWindowHandle;
            string popupWindowHandle = driver.WindowHandles[1]; // Assumes there are only two windows
            driver.SwitchTo().Window(popupWindowHandle);*/

            // Now, you are in the popup window; locate and fill the form elements
            IWebElement nameInput = driver.FindElement(By.CssSelector("#derivedPointsDialog > div > div > div.modal-body > div > div > div:nth-child(1) > div > input"));
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string pointname = "tbd12"+formattedDateTime;
            nameInput.SendKeys(pointname);
            Thread.Sleep(5000);

            IWebElement dropdownElement = driver.FindElement(By.Id("MainContent_ctl01_ddlCalculationType"));
            SelectElement select = new SelectElement(dropdownElement);
            string valueToSelect = "Constant";
            select.SelectByText(valueToSelect);
            Thread.Sleep(5000);

            IWebElement nameInput1 = driver.FindElement(By.CssSelector("#derivedPointsDialog > div > div > div.modal-body > div > div > div:nth-child(6) > div.col-xs-2 > input"));
            nameInput1.SendKeys("2");
            Thread.Sleep(5000);

            // Additional form filling logic goes here...

            // After filling the form, you can submit or perform other actions
            IWebElement submitButton = driver.FindElement(By.CssSelector("#derivedPointsDialog > div > div > div.modal-footer > div > button.btn.btn-primary"));
            submitButton.Click();
            Thread.Sleep(5000);

            // Switch back to the main window
            //driver.SwitchTo().Window(mainWindowHandle);
        }


        public void searchapoint()
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true)
            .Build();

            // Get values from configuration
            string searchText1 = config["AppSettings:PointName"];


            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"MainContent_Site Point List35\"]/div[1]/div[3]/div/ul/li[3]/span"));
            element.Click();
            bool isTextPresent = IsTextPresent(driver, searchText1);

            if (isTextPresent)
            {
                Console.WriteLine($"Text '{searchText1}' is present on the page.");

                return;
            }



            int A = 2;
            do
            {

                IWebElement element1 = driver.FindElement(By.LinkText($"{A}"));

                element1.Click();
                Thread.Sleep(4000);

                string pageSource = driver.PageSource;
                if (pageSource.Contains(searchText1))
                {
                    Console.WriteLine("Point Found");
                    break;
                }
                else
                    A = A + 1;

            } while (A < A + 1);
        }

        static bool IsTextPresent(IWebDriver driver, string searchText1)
        {
            try
            {
                // Use XPath to locate elements containing the specified text
                IWebElement element = driver.FindElement(By.XPath($"//*[contains(text(), '{searchText1}')]"));
                return element != null && element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
