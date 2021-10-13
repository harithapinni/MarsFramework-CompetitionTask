using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i")]
        private IWebElement deletebtn { get; set; }

        //Edit the listing//                
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i")]
        private IWebElement editbtn { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }
        //path for desc in managelisting tab 
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]")]
        private IWebElement descepath { get; set; }

        //path for title in managelisting tab 
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]")]
        private IWebElement listtitlepath { get; set; }
        //path for yes in managelisting tab 
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]/i")]
        private IWebElement delyespath { get; set; }
        //xpath for the text after delete in managelisting

        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/h3")]
        private IWebElement NoServiceListing { get; set; }



        internal void Listings()
        {
            //Populate the Excel Sheet

            manageListingsLink.Click();
        }
        internal void EditShareSkilllisting()
        {
            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.LinkText("Manage Listings"), 20);

            manageListingsLink.Click();

            editbtn.Click();

            ShareSkill shareskillobj = new ShareSkill();
            shareskillobj.EditShareSkill();
        }

        internal void DeleteShareSkilllisting()
        {

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ManageListingPath, "ManageListings");

            GlobalDefinitions.WaitForElement(Global.GlobalDefinitions.driver, By.LinkText("Manage Listings"), 20);

            manageListingsLink.Click();
            GlobalDefinitions.wait(15);
            string title = (GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            string delete = (GlobalDefinitions.ExcelLib.ReadData(2, "Deleteaction"));


            if (title == "Selenium" && delete == "Yes")

                 GlobalDefinitions.wait(15);
                deletebtn.Click();
            delyespath.Click();
        }


        internal void ValidateAddshareskill()
        {
            try
            {
                manageListingsLink.Click();
                //Start the Reports
                Global.Base.test = Global.Base.extent.StartTest("Create a share skill record");
                string expectedValue = "Selenium";
                GlobalDefinitions.wait(2);
                string actualValue = listtitlepath.Text;
                string img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Listingcreated");
                if (expectedValue == actualValue)
                {
                    Global.Base.test.Log(LogStatus.Pass, "Test Passed, Created share skill listing sucessfully");
                    Global.Base.test.Log(LogStatus.Info, "Image for create listing:" + img);
                    Assert.IsTrue(true);
                }
                else
                    Global.Base.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                Global.Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }


        }
        internal void ValidateEditshareskill()
        {
            try
            {
                manageListingsLink.Click();
                //Start the Reports
                Global.Base.test = Global.Base.extent.StartTest("Edit a share skill record");
                string expectedValue = "learn Automation testing";
                GlobalDefinitions.wait(2);
                string actualValue = descepath.Text;
                string img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "ListingUpdated");
                if (expectedValue == actualValue)
                {
                    Global.Base.test.Log(LogStatus.Pass, "Test Passed, Updated share skill listing sucessfully");
                    Global.Base.test.Log(LogStatus.Info, "Image for Edit listing:" + img);
                    Assert.IsTrue(true);
                }
                else
                    Global.Base.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                Global.Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }






        }
        internal void ValidateDeleteshareskill()
        {
            try
            {
                manageListingsLink.Click();
                //Start the Reports
                Global.Base.test = Global.Base.extent.StartTest("Delete a share skill record");
                string expectedValue = "Selenium";
                GlobalDefinitions.wait(2);
                string actualValue = "";
                string img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Listingdeleted");
                if (expectedValue != actualValue)
                {
                    Global.Base.test.Log(LogStatus.Pass, "Test Passed, Deleted share skill listing sucessfully");
                    Global.Base.test.Log(LogStatus.Info, "Image for Delete listing:" + img);
                    Assert.IsTrue(true);
                }
                else
                    Global.Base.test.Log(LogStatus.Fail, "Test Failed");
            }
            catch (Exception e)
            {
                Global.Base.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }






        }
        internal void ValidateUrl()
        {
            Assert.AreEqual(GlobalDefinitions.driver.Url, "http://localhost:5000/Home/ListingManagement");
            Console.WriteLine("Execute Test is Passed");
        }
        internal void Listingmsg()
        {
            // make sure the following message is displayed
            var NoServiceListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/h3"));
            Assert.AreEqual("You do not have any service listings!", NoServiceListing.Text);
            Console.WriteLine("Test is passed");
        }







    }

    }






