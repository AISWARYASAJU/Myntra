using Bunny.PageObjects;
using Bunny.PageObjects;
using Bunny.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunny.TestScripts
{
    [TestFixture]
    internal class BunnyCartTests : CoreCodes
    {

        [Test]
        public void SignUpTest()
        {
            string currdir = Directory.GetParent(@"../../../").FullName;
            string filepath = currdir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day).CreateLogger();
            BunnyCartHomePage bunnyCartHomePage = new BunnyCartHomePage(driver);
            bunnyCartHomePage.ClickCreateAccountLink();
            Thread.Sleep(1000);

            try
            {
                Assert.That(driver?.FindElement(By.XPath("//div[" +
                    "@class='modal-inner-wrap']//following::h1[2]")).Text,
                    Is.EqualTo("Create an Account"));
                test = extent.CreateTest("Create Account Link Test");
                test.Pass("Create Account Link success");

            }
            catch (AssertionException)
            {
                test = extent.CreateTest("Create Account Link Test");
                test.Fail("Create Account Link failed");

            }


            Assert.That(driver?.FindElement(By.XPath("//div[" +
                 "@class='modal-inner-wrap']//following::h1[2]")).Text,
                 Is.EqualTo("Create an Account"));

            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "CreateAccount";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {

                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;
                string? pwd = excelData?.Password;
                string? conpwd = excelData?.ConfirmPassword;
                string? mbno = excelData?.MobileNumber;

                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");


                bunnyCartHomePage.ClickCreateAccountButton(firstName, lastName, email, pwd, conpwd, mbno);


            }

        }
        //try
        //{
        //    Assert.That(driver.FindElement(By.XPath("//div[" + "@class='modal-inner-wrap']//following::h1[2]")).Text,
        //        Is.EqualTo("Create an Account"));
        //    bunnyCartHomePage.ClickCreateAccountButton("raj", "kumar", "raj@gmail.com", "12345", "12345", "9876543423");
        //}
        //catch(AssertionException)
        //{
        //    Console.WriteLine("Sign Up failed");
        //}

    }
}
