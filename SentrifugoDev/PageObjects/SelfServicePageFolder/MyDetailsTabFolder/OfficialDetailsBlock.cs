using OpenQA.Selenium;
using SentrifugoDev.CommonLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentrifugoDev.PageObjects.SelfServicePageFolder.MyDetailsTabFolder
{
    public class OfficialDetailsBlock
    {
        private IWebDriver driver;
        protected CommonMethods commonMethods;

        public OfficialDetailsBlock(IWebDriver driver)
        {
            this.driver = driver;
            commonMethods = new CommonMethods(driver);
        }

        #region Official Details Block Elements

        private const string xpathNamesOfFields = "//div[@class = 'main_view']/div[contains(@class,'main_view')]//div[@class = 'width_20']";
        private readonly By NamesOfFieldsLocator = By.XPath(xpathNamesOfFields);

        private const string xpathDataOfFields = "//div[@class = 'main_view']/div[contains(@class,'main_view')]//div[@class = 'width_80']";
        private readonly By DataOfFieldsLocator = By.XPath(xpathDataOfFields);

        private const string xpathDataOfOfficialDetailsBlock = "//div[@class = 'main_view']/div[contains(@class,'main_view')]/div/div";
        private readonly By DataOfOfficialDetailsBlockLocator = By.XPath(xpathDataOfOfficialDetailsBlock);

        #endregion

        #region Official Details Block Methods

        /// <summary>
        /// Method gets all data from Official block and returns dictionary list (Field name, data)
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string> GetListOfOfficialDetailsData()
        {
            Dictionary<string, string> listOfOfficialDetailsData = new Dictionary<string, string>();
            List<string> listOfofficialDetailsData = new List<string>();
            var officialDetailsDataElements = driver.FindElements(DataOfOfficialDetailsBlockLocator);
            for (int k = 0; k < officialDetailsDataElements.Count; k++)
            {
                listOfofficialDetailsData.Add(officialDetailsDataElements[k].Text);
            }
            for (int k = 0; k < listOfofficialDetailsData.Count; k=k+2)
            {
                listOfOfficialDetailsData.Add(listOfofficialDetailsData[k], listOfofficialDetailsData[k+1]);
            }
            return listOfOfficialDetailsData;
        }

        #endregion
    }
}
