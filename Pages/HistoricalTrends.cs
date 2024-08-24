using ExcelDataReader;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class HistoricalTrends
    {
        private IWebDriver driver;
        public HistoricalTrends(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AddPointstoHistoricalTrend()
        {
            IWebElement elementHTP = driver.FindElement(By.XPath("//span[@class='glyphicon glyphicon-plus']"));
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
            Thread.Sleep(5000);

        }




    }
}
