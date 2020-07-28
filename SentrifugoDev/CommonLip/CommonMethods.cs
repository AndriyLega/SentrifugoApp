using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SentrifugoDev.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.CommonLip
{
    public class CommonMethods
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;
        private const int timeOut = 10;
        private ITakesScreenshot screenshotDriver;

        public CommonMethods(IWebDriver driver)
        {
            this.driver = driver;
            js = driver as IJavaScriptExecutor;
            screenshotDriver = driver as ITakesScreenshot;
        }

        /// <summary>
        /// Waiter with ExpectedCondition = ElementExists
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="maxTimeout"></param>
        /// <returns></returns>
        public IWebElement WaitForElementIsPresent(By locator, int maxTimeout = 10)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxTimeout)).Until(ExpectedConditions.ElementExists(locator));
        }

        /// <summary>
        /// Waiter with ExpectedCondition = ElementIsVisible
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="maxTimeout"></param>
        /// <returns></returns>
        public IWebElement WaitForElementIsVisable(IWebDriver driver, By locator, int maxsecond = timeOut)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(maxsecond)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Method check if element present and returns true oe false
        /// </summary>
        /// <param name="locator"></param>
        /// <returns></returns>
        public bool IsElementPresent(By locator)
        {
            try
            {
                WaitForElementIsVisable(driver, locator);
                return true;
            }
            catch (WebDriverTimeoutException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Method waits till block page loader disappears
        /// </summary>
        public void WaitForElementDisappears(By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        /// <summary>
        /// Method gets and returns web element
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="message"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public IWebElement GetElementByWithLogs(IWebDriver driver, By by, string message, int second = timeOut)
        {
            IWebElement element = null;
            try
            {
                element = WaitForElementIsVisable(driver, by, second);
            }
            catch (WebDriverTimeoutException e)
            {
                LogUtil.WriteDebug("I've been waiting 10 seconds element but it is not visible");
                LogUtil.WriteDebug("**********************" + message + "********************** " + by);
                Assert.Fail(message);
            }
            return element;
        }

        /// <summary>
        /// Method selects option in dropdown
        /// </summary>
        public enum SelectBy { Value, Text }
        public void SelectOptionInDropDownBy(SelectBy by, IWebElement dropDownElement, string value)
        {
            var selectElement = new SelectElement(dropDownElement);
            switch (by)
            {
                case SelectBy.Value:
                    {
                        //select by value
                        selectElement.SelectByValue(value);
                        break;
                    }

                case SelectBy.Text:
                    {
                        //select by text
                        selectElement.SelectByText(value);
                        break;
                    }
            }

        }

        #region Scrolls Methods
        
        /// <summary>
        /// Method scrolls horizontal scroll to the last column
        /// </summary>
        public void HorizontalScrollToTheLastColumn()
        {
            js.ExecuteScript("document.querySelector('table th:last-child').scrollIntoView();");
            LogUtil.WriteDebug("Scrolled to the last column of the table");
        }

        /// <summary>
        /// Methods scrolls to the bottom of the page
        /// </summary>
        public void ScrollToTheBottomOfThePage()
        {
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            LogUtil.WriteDebug("Scrolled to bottom of the page");
        }

        /// <summary>
        /// Methods scrolls to the element
        /// </summary>
        /// <param name="element"></param>
        public void ScrollToTheElement(IWebElement element)
        {
            js.ExecuteScript("arguments[0].scrollIntoView();", element);
            LogUtil.WriteDebug("Scrolled to the element " + element);
        }

        #endregion

        /// <summary>
        /// Method take a screenshot of current opened page in browser
        /// </summary>
        public void TakeScreenshot()
        {
            string currentpath = TestContext.CurrentContext.TestDirectory;
            string[] pathList = currentpath.Split('\\');
            string sequence = @"\";
            string subPath = "Users/Andriy/Desktop/Screenshots";
            string path = pathList[0] + sequence + subPath + sequence;
            string timestamp = DateTime.Now.ToString("yyy-MM-dd-hh-mm-ss");
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(path + timestamp + ".jpeg", ScreenshotImageFormat.Jpeg);
            LogUtil.WriteDebug("Please find more information on this screen: " + timestamp + ".jpeg");
        }
    }
}   

