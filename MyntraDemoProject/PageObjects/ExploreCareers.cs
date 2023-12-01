using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyntraDemoProject.PageObjects
{
    internal class ExploreCareers
    {

        IWebDriver driver;
        public ExploreCareers(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "/html/body/main/a/img")]
        [CacheLookup]
        private IWebElement? ExploreButton { get; set; }

        public Technology ExploreClick()
        {
           // ExploreButton?.Click();
            return new Technology(driver);
            Thread.Sleep(3000);
                

        }
    }

   
}
