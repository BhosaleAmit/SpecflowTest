using OpenQA.Selenium;
namespace SpecFlowTest
{
    public static class Driver
    {
        private static IWebDriver _driver;
        public static IWebDriver QADriver
        {
            get { return _driver; }
            set { _driver = value; }
        }
        

    }
}
