using NUnit.Framework;
using OpenQA.Selenium;
using TaskWorldAutomation.Helper;

namespace TaskWorldAutomation.Views
{
    class MyProjectView
    {
        #region My Project element locators
        private const string addNewProjectButton = "//div[@class='tw-new-project-button-box ax-new-project-button-box']";
        private const string projectNameField = "//input[@name='project-name']";
        private const string projectDescriptionField = "//input[@name='description']";
        private const string nextChooseATemplateButton = "//div[@class='tw-new-project__choose-workflow-button']/button";
        private const string createProjectButton = "//button/div[text()='Create Project']";
        private const string getProjectTitle = "//div[@class='tw-project-header__title']/div/div";
        #endregion

        internal void ClickAddNewProject()
        {
            FrameworkHelper.ClickElementByXpath(addNewProjectButton);
        }

        internal void SetProjectName(string name)
        {
            IWebElement emailLocator = FrameworkHelper.GetElementByXpath(projectNameField);
            FrameworkHelper.SetText(emailLocator, name);
        }

        internal void SetProjectDescription(string description)
        {
            IWebElement passwordLocator = FrameworkHelper.GetElementByXpath(projectDescriptionField);
            FrameworkHelper.SetText(passwordLocator, description);
        }


        private void ClickChooseATemplateButton()
        {
            FrameworkHelper.ClickElementByXpath(nextChooseATemplateButton);
        }

        private void ClickCreateProjectButton()
        {
            FrameworkHelper.ClickElementByXpath(createProjectButton);
        }

        internal void CreateNewProject(string pName, string pDesc)
        {
            FrameworkHelper.WaitForLoading();
            ClickAddNewProject();
            SetProjectName(pName);
            SetProjectDescription(pDesc);
            ClickChooseATemplateButton();
            ClickCreateProjectButton();
            Assert.True(FrameworkHelper.GetElementByXpath(getProjectTitle).Displayed, "Project creation is unsuccessful");
        }


    }   

}

