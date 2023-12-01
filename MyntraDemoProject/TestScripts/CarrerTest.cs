using MyntraDemoProject.PageObjects;
using MyntraDemoProject.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyntraDemoProject.TestScripts
{
    internal class CarrerTest : CoreCodes
    {

        [Test]
        public void CarrerInfo()
        {
            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

           /* Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();*/




             MyntraHomePage mhpc = new(driver);
              mhpc.CarrersClick();

              ExploreCareers exp = new(driver);
              IWebElement element = driver.FindElement(By.XPath("/html/body/main/a/img"));
              Thread.Sleep(5000);
              ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
              exp.ExploreClick();
              Thread.Sleep(5000);

             var t = new Technology(driver);
              t.KnowMoreClick();

            /*Apply apply = new(driver);
            Log.Information("Create Career Test Started");
            apply.ApplyButtonClick();
            Log.Information("Create Career Link Clicked");
            Thread.Sleep(2000);*/


            /*try
            {


                Assert.IsTrue(driver?.FindElement(By.XPath(
                    "(//a[@class='shape-btn'])[1]")).Text
                    == "Apply", $"Test failed for Apply");

                Log.Information("Test passed for Create Account");

                test = extent.CreateTest("Create Apply Link Test");
                test.Pass("Create Apply Link success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Create Account. \n Exception: {ex.Message}");

                test = extent.CreateTest("Create Appy Link Test");
                test.Fail("Create Apply Link failed");
            }*/

            string? excelFilePath = currdir + "/TestData/InputData.xlsx";
            string? sheetName = "Career";

            List<ExcelData> excelDataList = ExcelUtils.ReadExcelData(excelFilePath, sheetName);
            foreach (var excelData in excelDataList)
            {



              /*  MyntraHomePage mhpc = new(driver);
                mhpc.CarrersClick();
                ExploreCareers exp = new(driver);
                IWebElement element = driver.FindElement(By.XPath("/html/body/main/a/img"));
                Thread.Sleep(5000);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
                exp.ExploreClick();
                Thread.Sleep(5000);
                var t = new Technology(driver);
                t.KnowMoreClick();*/
                string? firstName = excelData?.FirstNameInputBox;
                string? lastName = excelData?.LastNameInputBox;
                string? email = excelData?.LastNameInputBox;
                string? phoneNo = excelData?.LastNameInputBox;
                string? location = excelData?.LastNameInputBox;
               // apply.FinalSubitLink(firstName, lastName, email, phoneNo, location);
            }
            Log.CloseAndFlush();












        }
    }
}
      
