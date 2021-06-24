using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SpecFlowTest
{
    class WebElementExtension
    {
        
        /// <summary>
        /// Helper method to find out the elements in webpage
        /// </summary>
        /// <param name="elementIdentifier"></param>
        /// <param name="byIdentifier"></param>
        /// <returns></returns>
        public static IWebElement findElementByConfig(string elementIdentifier, string byIdentifier)//, String locator, String identifier)
        {
            IWebElement searchResult = null;
            DefaultWait<IWebDriver> fluentWait = null;
            IWebDriver driver = Driver.QADriver;

            try
            {

                fluentWait = new DefaultWait<IWebDriver>(driver);
                fluentWait.Timeout = TimeSpan.FromSeconds(5);
                fluentWait.PollingInterval = TimeSpan.FromMilliseconds(1000);
                fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                fluentWait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
                fluentWait.IgnoreExceptionTypes(typeof(ElementNotSelectableException));

                fluentWait.Message = "Element to be searchDefaultWaited not found";


                switch (byIdentifier)
                {
                    case "name":
                        searchResult = fluentWait.Until(x => x.FindElement(By.Name(elementIdentifier)));
                        break;
                    case "value":
                        break;
                    case "CssSelector":
                        searchResult = fluentWait.Until(x => x.FindElement(By.CssSelector(elementIdentifier)));
                        break;
                    case "id":
                        searchResult = fluentWait.Until(x => x.FindElement(By.Id(elementIdentifier)));
                        break;
                    case "XPath":
                        searchResult = fluentWait.Until(x => x.FindElement(By.XPath(elementIdentifier)));
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("No result found");
                        break;
                }

                return searchResult;
                
            }
            catch (Exception e)
            {
                throw new NoSuchElementException("Element not found: " + e.Message);
            }
            

        }

        /// <summary>
        /// Find out minimum value of wishlist items
        /// </summary>
        public static int iterateWishListTable(string elementIdentifier, string byIdentifier)
        {
            //IWebElement tableElement = findElementByConfig(@"//table[contains(@class,'shop_table cart wishlist')]", "XPath");

            IWebElement tableElement = findElementByConfig(elementIdentifier, byIdentifier);

            //Init TR elements from table we found into list
            IList<IWebElement> trCollection = tableElement.FindElements(By.TagName("tr"));
            //define TD elements collection.
            IList<IWebElement> tdCollection;
            var minRecord = 0;
            var minValue = 0;

            var ctr = 0;
            foreach (IWebElement element in trCollection)
            {
                if (ctr == 0) 
                {
                    ctr++;
                    continue;
                }
                tdCollection = element.FindElements(By.TagName("td"));

                //now in the List you have all the columns of the row
                //string column1 = tdCollection[0].Text;
                //string column2 = tdCollection[1].Text;
                //string column3 = tdCollection[2].Text;
                string column4 = tdCollection[3].Text;
                var stringList = column4.Split(new[] { "£" }, StringSplitOptions.None);
                if(Int32.Parse(stringList[1].Substring(0, 2)) <= Int32.Parse(stringList[2].Substring(0, 2)))
                {
                   if (minRecord ==0)
                    {
                        minRecord = ctr;
                        minValue = Int32.Parse(stringList[1].Substring(0, 2));
                    }
                    else
                    {
                        if(minValue >= Int32.Parse(stringList[1].Substring(0, 2)))
                        {
                            minRecord = ctr;
                            minValue = Int32.Parse(stringList[1].Substring(0, 2));
                        }
                    }
                }
                else{

                    if (minRecord == 0)
                    {
                        minRecord = ctr;
                        minValue = Int32.Parse(stringList[2].Substring(0, 2));
                    }
                    else
                    {
                        if (minValue >= Int32.Parse(stringList[2].Substring(0, 2)))
                        {
                            minRecord = ctr;
                            minValue = Int32.Parse(stringList[2].Substring(0, 2));
                        }
                    }
                }
                ctr++;
                
            }
            return minRecord;
        }

        /// <summary>
        /// Counts the rows of HTML table
        /// </summary>
        /// <param name="elementIdentifier"></param>
        /// <param name="byIdentifier"></param>
        /// <returns></returns>
        public static int getTableRowCount(string elementIdentifier, string byIdentifier)
        {
            IWebElement tableElement = findElementByConfig(elementIdentifier, byIdentifier);

            //Init TR elements from table we found into list
            IList<IWebElement> trCollection = tableElement.FindElements(By.TagName("tr"));

            return trCollection.Count == 0 ? 0 : trCollection.Count;
        }
    }
}

