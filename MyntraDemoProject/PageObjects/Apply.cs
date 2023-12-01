using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyntraDemoProject.PageObjects
{
    internal class Apply
    {
        IWebDriver driver;
        public Apply(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "/html/body/main/div[1]/div/div/div/div[1]/div/a/text()")]
        [CacheLookup]
        private IWebElement? ApplyButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@type='text' and @name='first_name']")]
        [CacheLookup]
        private IWebElement? FirstNameInputBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "//input[@type='text' and @name='last_name']")]
        [CacheLookup]
        private IWebElement? LastNameInputBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "//input[@type='email' and @name='email']")]
        [CacheLookup]
        private IWebElement? EmailInputBox { get; set; }

        [FindsBy(How = How.ClassName, Using = "//input[@type='text' and @name='phone']")]
        [CacheLookup]
        private IWebElement? PhoneNum { get; set; }


        [FindsBy(How = How.ClassName, Using = "//input[@type='text' and @name='location']")]
        [CacheLookup]
        private IWebElement? Location { get; set; }

        [FindsBy(How = How.ClassName, Using = "//*[@id=\"jobapply-form\"]/button/span")]
        [CacheLookup]
        private IWebElement? FinalSubmit { get; set; }

        public void ApplyButtonClick()
        {
            ApplyButton?.Click();

        }

        public void FinalSubitLink(string firstName, string lastName, string email, string phoneNo, string location)
        {
            IWebElement modal = new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                    By.XPath("(//div[@class='modal-body'])[1]")));
            FirstNameInputBox?.SendKeys(firstName);
            LastNameInputBox?.SendKeys(lastName);
            EmailInputBox?.SendKeys(email);
            PhoneNum?.SendKeys(phoneNo);
            Location?.SendKeys(location);
            FinalSubmit?.Click();



        }



    }
}
