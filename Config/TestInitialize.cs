using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using SpecFlowTest.Config;
namespace SpecFlowTest
{
    public abstract class TestInitialize
    {
        public static void triggerSetting()
        {
            ReadConfigSetting.setFrameworkSettings();

            launchBrowser();
        }
        private static void launchBrowser()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\SpecFlowPlusRunner\\netcoreapp3.1", "");
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver.QADriver = new ChromeDriver(dir,options);
            Driver.QADriver.Navigate().GoToUrl(Setting.AUT);
        }
    }

}
