using MyntraDemoProject.PageObjects;
using MyntraDemoProject.Utilities;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyntraDemoProject.TestScripts
{
    [TestFixture]
    internal class TestScriptsSmoke: CoreCodes
    {
        [Test]
        [Order(1)]

        public void TitleSearch()
        {
            var title = new MyntraHomePage(driver);
            title.TitleTest();
        }

        [Test]
        [Order(2)]
        public void OrganizationSearch()
        {
            var org = new MyntraHomePage(driver);
            org.OrganizationTypeTest();
        }

        [Test]
        [Order(3)]
        public void WishListSearch()
        {
            var wish = new MyntraHomePage(driver);
            wish.WishClick();
        }

        [Test]
        [Order(4)]
        public void FAQSearch()
        {
            var faq = new MyntraHomePage(driver);
            faq.FAQClick();
            Thread.Sleep(3000);
            faq.ContactUsClick();
            faq.LoginClick();
            
        }

        [Test]
        [Order(5)]
        public void GiftSearch()
        {
            var gif = new MyntraHomePage(driver);
            gif.GiftClick();
            gif.SendGiftClick();
            gif.NextGFClick();
        }



        /*  public void MenMouseOver()
          {
              Actions actions = new Actions(driver);
              Action mouseOverClick = () => actions.MoveToElement(Men).Build().Perform();
              mouseOverClick.Invoke();


          }
        */

        [Test]
        [Order(6)]
        public void MyntraInsideSearch()
        {
            var inside = new MyntraHomePage(driver);
            inside.MyntraInsideClick();
            inside.MyntraLoginInsideClick();
        }


    }
}
