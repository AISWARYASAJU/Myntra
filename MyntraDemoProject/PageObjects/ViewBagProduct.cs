using MyntraDemoProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.DOM;
using SeleniumExtras.PageObjects;

namespace MyntraDemoProject.PageObjects
{
    internal class ViewBagProduct
    {
        IWebDriver driver;
        public ViewBagProduct(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        /* [FindsBy(How = How.ClassName, Using = "itemContainer-base-itemLink")]
         [CacheLookup]
         private IWebElement? AddedItem { get; set; }
        */

       /* [FindsBy(How = How.XPath, Using = "//*[@id=\"cartItemsList\"]/div[1]/div/div/div[2]/div[2]/div/div[3]/div[1]/div[2]")]
        [CacheLookup]
        private IWebElement? Qty { get; set; }


        [FindsBy(How = How.XPath, Using = "(//div[@class='dialogs-base-display'])[1]")]
        [CacheLookup]
        private IWebElement? QtyNum { get; set; }*/

        [FindsBy(How = How.XPath, Using = "//div[text()='PLACE ORDER']//parent::button")]
        [CacheLookup]
        private IWebElement? PlaceOrderButton { get; set; }

        public void PlaceOrderClicked()
        {
            Thread.Sleep(5000);
            PlaceOrderButton?.Click();
            
        }

        



    }
}
