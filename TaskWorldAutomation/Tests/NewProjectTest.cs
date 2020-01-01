using NUnit.Framework;
using System;
using TaskWorldAutomation.Helper;
using TaskWorldAutomation.Views;
using System.IO;
using System.Data;

namespace TaskWorldAutomation.Tests
{
    //[TestFixture(BrowserType.InternetExplorer, Category = "Selenium_InternetExplorer")]
    [TestFixture(BrowserType.Chrome, Category = "Selenium_Chrome")]
    class NewProjectTest :UITestFixtureBase
    {
        public NewProjectTest(BrowserType browserType) : base(browserType) { }

        [TestCase]
        public void CreateNewProjectTest()
        {
            #region TestData
            string dataFile = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + "TestData\\CreateNewProjectTest.xlsx");
            var NewProjectTdo = ExcelHelper.ReadTestData(dataFile, "Sheet1");
            #endregion

            LogInView loginView = new LogInView();
            MyProjectView myProjectView = new MyProjectView();
            MyTaskView myTaskView = new MyTaskView();

            foreach (DataRow data in NewProjectTdo.Rows)
            {
                
                loginView.Login(data["emailAddress"].ToString(), data["password"].ToString());

                myProjectView.CreateNewProject(data["projectName"].ToString(), data["projectDescription"].ToString());

                myTaskView.CreateNewTask(data["taskListName"].ToString(), data["taskName"].ToString());

                myTaskView.CompleteTask();

                myTaskView.OpenCompletedTask();

            }
                
                
        }
    }
}
