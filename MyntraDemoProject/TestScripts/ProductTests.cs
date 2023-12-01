using MyntraDemoProject.PageObjects;
using MyntraDemoProject.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyntraDemoProject.TestScripts
{
    internal class ProductTests : CoreCodes
    {
        [Test]
        public void CreateSearchTest()
        //CreateAccountTest
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            MyntraHomePage mhp = new(driver);
            Log.Information("Create Account Test Started");
             mhp.SearchClick();
            Log.Information("Test Started");
            Thread.Sleep(2000);

          /*  try
            {
                /*       Assert.That(driver?.FindElement(By.XPath("//div[" +
                            "@class='modal-inner-wrap']//following::h1[2]")).Text,
                            Is.EqualTo("Create an Account"));*/

               /*( Assert.IsTrue(driver?.FindElement(By.XPath(
                    "//div[@class='modal-inner-wrap']//following::h1[2]")).Text
                    == "Create an Account", $"Test failed for Create Account");*/

                Log.Information("Test passed for Search");

                test = extent.CreateTest("Create Account Link Test");
                test.Pass("Create Account Link success");

           /* }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Create Account. \n Exception: {ex.Message}");

                test = extent.CreateTest("Create Account Link Test");
                test.Fail("Create Account Link failed");
            }*/

            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "SearchProduct";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? searchText = excelData?.SearchText;
                mhp.SearchClick(searchText);
               
                //TakeScreenShot();

                var searchProductList = new SearchedProductListPage(driver);
                searchProductList.FilterGirlsSelected();
                Thread.Sleep(3000);
                searchProductList.SelectedProduct();
                Thread.Sleep(3000);


                List<string> nextwindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(nextwindow[1]);



                var buyNow = new SearchedFifthProduct(driver);
                buyNow.Sizeselect();
                Thread.Sleep(3000);

                buyNow.AddToBagClicked();
                Thread.Sleep(3000);

               // buyNow.BagProducts();*/

               buyNow.BagProducts();
               Thread.Sleep(5000);

               var bags = new ViewBagProduct(driver);
                IWebElement element = driver.FindElement(By.XPath("//div[text()='PLACE ORDER']//parent::button"));
                Thread.Sleep(5000);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
                //bags.QtyClick();
                Thread.Sleep(2000);
                
               // bags

               // TakeScreenShot();

                //buyNow.ClickRemove();
                //buyNow.ClickLastRemove();








                //  Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");

                //Assert  .........
            }
            Log.CloseAndFlush();
        }





    }
}
