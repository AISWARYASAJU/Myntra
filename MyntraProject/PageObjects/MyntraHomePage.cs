using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyntraProject.PageObjects
{
    internal class MyntraHomePage
    {
        IWebDriver driver;
        public MyntraHomePage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        //Arrange
        [FindsBy(How = How.ClassName, Using = "desktop-searchBar")]
        public IWebElement? SearchInputBox { get; set; }

        //Act
        public void SearchClick(string searchText)
        {
            SearchInputBox?.SendKeys(searchText);
            SearchInputBox?.SendKeys(Keys.Enter);
        }

    }
}
