using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyntraDemoProject.PageObjects
{
    internal class Technology
    {
        IWebDriver driver;
        public Technology(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//a[@class='full-link'])[1]")]
        [CacheLookup]
        private IWebElement? ClickButton { get; set; }

        public Job KnowMoreClick()
        {
            ClickButton?.Click();
            return new Job(driver);
            Thread.Sleep(3000);


        }
    }
}
