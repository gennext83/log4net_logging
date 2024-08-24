using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class ManageCompanies
    {
        private IWebDriver driver;
        public ManageCompanies(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Sites traverse()
        { 
        driver.FindElement(By.Id("MainContent_ctl01_gvCompanies_lnkSites_5")).Click();
        Thread.Sleep(5000);
            return new Sites(driver);
        }

    }
}
