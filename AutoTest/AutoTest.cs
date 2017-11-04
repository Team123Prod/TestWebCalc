using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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
            string fullPath = Path.GetFullPath(@"../../../WebCalc/Calc.html");
            driver.Navigate().GoToUrl("file:///" + fullPath);

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
            string fullPath = Path.GetFullPath(@"../../../WebCalc/Calc.html");
            driver.Navigate().GoToUrl("file:///" + fullPath);

            driver.FindElementById(id).SendKeys(key);
            string res = driver.FindElementById(id).GetAttribute("value");
            Assert.AreEqual(exp, res);

            driver.Close();
        }
    }
}
