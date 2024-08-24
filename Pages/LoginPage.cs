using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class LoginPage

    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ManageCompanies Login() 
        {
            driver.FindElement(By.Id("cphMain_txtUsername")).SendKeys("ajain");
        driver.FindElement(By.Id("cphMain_txtPassword")).SendKeys("TriPass99@");
        driver.FindElement(By.Id("cphMain_btnLogIn")).Click();
        Thread.Sleep(5000);
            return new ManageCompanies(driver);
        }

    }
}
