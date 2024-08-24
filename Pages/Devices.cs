using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class Devices
    {

        private IWebDriver driver;
        public Devices(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void addaDevice()
        {
            driver.FindElement(By.LinkText("Add a Device")).Click();
            Thread.Sleep(3000);
            IWebElement namefield = driver.FindElement(By.Id("txtName"));
            string textfield = "tbd#1";
            namefield.SendKeys(textfield);

            IWebElement dropdownElement = driver.FindElement(By.Id("ddlDeviceType"));
            SelectElement select = new SelectElement(dropdownElement);
            string valueToSelect = "BESS";
            select.SelectByText(valueToSelect);
            Thread.Sleep(5000);

            IWebElement dropdownElement1 = driver.FindElement(By.Id("ddlManufacturer"));
            SelectElement select1 = new SelectElement(dropdownElement1);
            string valueToSelect1 = "Generic";
            select1.SelectByText(valueToSelect1);
            Thread.Sleep(5000);
            driver.FindElement(By.Id("btnSave")).Click();
            Thread.Sleep(5000);
        }

    }
}
