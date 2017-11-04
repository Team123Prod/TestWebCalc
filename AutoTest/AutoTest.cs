using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoTest
{
    [TestClass]
    public class AutoTest
    {
        [DataTestMethod]
        [DataRow("A", true)]
        [DataRow("B", true)]
        [DataRow("Op", true)]
        [DataRow("Res", true)]
        [DataRow("Btn", true)]
        public void Test_Calc_Enabled(string id, bool exp)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///D:/ORT/ORT_all/TeamCityCalcs/Calc_GET%20for%20HTTP.html");

            bool res = driver.FindElementById(id).Enabled;
            Assert.AreEqual(exp, res);

            driver.Close();
        }

        [DataTestMethod]
        [DataRow("A", "5", "5")]
        [DataRow("B", "5", "5")]
        [DataRow("Op", "+", "+")]
        public void Test_Calc_Keys(string id, string key, string exp)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///D:/ORT/ORT_all/TeamCityCalcs/Calc_GET%20for%20HTTP.html");

            driver.FindElementById(id).SendKeys(key);
            string res = driver.FindElementById(id).GetAttribute("value");
            Assert.AreEqual(exp, res);

            driver.Close();
        }
    }
}
