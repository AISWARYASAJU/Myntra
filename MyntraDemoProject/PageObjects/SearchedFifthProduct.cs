using MyntraDemoProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MyntraDemoProject.PageObjects
{
    internal class SearchedFifthProduct
    {
        IWebDriver? driver;
        public SearchedFifthProduct(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        ////*[@id="sizeButtonsContainer"]/div[2]/div[2]/div[1]
        [FindsBy(How = How.XPath, Using = "(//div[@class='size-buttons-buttonContainer'])[2]")]
        [CacheLookup]
        private IWebElement? SelectedSize { get; set; }// 4 -4.5 size

        /*  [FindsBy(How = How.XPath, Using = "//*[@id=\"mountRoot\"]/div/div[1]/main/div[2]/div[2]/div[2]/div[3]/div/div[1]")]
          [CacheLookup]
          private IWebElement? AddToBag { get; set; }*/

        [FindsBy(How = How.ClassName, Using = "pdp-add-to-bag")]
        [CacheLookup]
        private IWebElement? AddToBag { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[text()='Bag']")]
        [CacheLookup]
        private IWebElement? GoToBag { get; set; }

        /* [FindsBy(How = How.ClassName, Using = "itemComponents-base-quantity")]
         [CacheLookup]
         private IWebElement? Qty { get; set; }*/

        /*

        //[FindsBy(How = How.ClassName, Using = "desktop-cart")]
        //[CacheLookup]
        //private IWebElement? Bag { get; set; }


        //[FindsBy(How = How.XPath, Using = "//*[@id=\"appContent\"]/div/div/div/div/div[1]/div[4]/div[3]/div[1]/button")]
        //[CacheLookup]
        //private IWebElement? Remove { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id=\"appContent\"]/div/div/div/div/div[1]/div[4]/div[4]/div/div/div[2]/div[1]/button")]
        //[CacheLookup]
        //private IWebElement? LastRemove { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id=\"1\"]")]
        //[CacheLookup]
        //private IWebElement? SelectedQuantity { get; set; }
       */



        //Act
        public void Sizeselect()
         {
            SelectedSize?.Click();
         }

         public void AddToBagClicked()
        {
             
            AddToBag?.Click();
         }
   
        public ViewBagProduct BagProducts()
        {
           GoToBag?.Click();
            Thread.Sleep(5000);
            return new ViewBagProduct(driver);
        }

        /* public void QtySelected(string qty)
         {
            Qty?.Click();

         }*/
        // public void BagClicked()
        // {
        //     Bag?.Click();
        // }
        // public void QtySelected(string qty)
        // {
        //     SelectedQuantity?.Click();

        // }
        // public void ClickRemove()
        // {
        //     Remove?.Click();
        // }

        //public void ClickLastRemove()
        //{
        //    LastRemove?.Click();

        //}
    }
}
