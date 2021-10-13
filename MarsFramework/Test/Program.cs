using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {

            [Test]
            public void Test()
            { 

                ShareSkill shareskillobj = new ShareSkill();
                shareskillobj.EnterShareSkill();
               


                //edit listing  from managelisting tab
                ManageListings managelistobj = new ManageListings();
                managelistobj.ValidateAddshareskill();
                


                managelistobj.EditShareSkilllisting();
                managelistobj.ValidateEditshareskill();
               
                managelistobj.DeleteShareSkilllisting();
                managelistobj.ValidateDeleteshareskill();
                managelistobj.ValidateUrl();
                managelistobj.Listingmsg();



            }
      

            



        }
    }
}