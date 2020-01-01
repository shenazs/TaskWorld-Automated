using NUnit.Framework;
using OpenQA.Selenium;
using TaskWorldAutomation.Helper;

namespace TaskWorldAutomation.Views
{
    class MyTaskView
    {
        #region My Task element locators
        private const string createNewTaskList = "//div[@class='tw-new-project-button-box ax-new-project-button-box']";
        private const string getProjectTitle = "//div[@class='tw-project-header__title']/div/div";
        private const string taskListTitle = "//div/input[contains(@class,'new-tasklist-name-textfield')]";
        private const string addNewTask = "//div/section[@class='tw-tasklist ax-tasklist --expanded']//div[@class='tw-click-area tw-tasklist-header__add-icon ax-add-task-button']";
        private const string enterNewTaskDescriptionField = "//div[1]/textarea";
        private const string createButton = "//button[contains(@class,'create-task-button')]";
        private const string openTask = "//div/section[@data-task-title='{0}']";
        private const string openTaskTitle = "//div[@class='tw-editable-panel-title__text']";
        private const string closeTask = "//i[@class='tw-icon tw-icon-close --name_close']";
        private const string completeTaskCheckBox = "//div[@class='tw-click-area tw-task-checkbox ax-task-checkbox --size-regular']";
        private const string completedTask = "//div[@class='tw-kanban-item tw-tasklist__kanban-item --is-completed']";
        private const string openCompletedTask = "//div[@class='tw-kanban-item tw-tasklist__kanban-item --is-completed']";
        private const string completedTaskStat = "//div[@class='tw-task-completed-stat']/span";
        #endregion

        internal void ClickCreateNewTaskList()
        {
            FrameworkHelper.ClickElementByXpath(createNewTaskList);
        }

        internal void ClickCreateTaskButton()
        {
            FrameworkHelper.ClickElementByXpath(createButton);
        }

        internal void SetTaskListName(string name)
        {
            IWebElement taskList = FrameworkHelper.GetElementByXpath(taskListTitle);
            FrameworkHelper.SetText(taskList, name);
            taskList.SendKeys(Keys.Enter);
        }

        internal void SetTaskDescription(string description)
        {
            IWebElement taskDescription = FrameworkHelper.GetElementByXpath(enterNewTaskDescriptionField);
            FrameworkHelper.SetText(taskDescription, description);
        }


        internal void ClickAddNewTask()
        {
            var element = FrameworkHelper.GetElementByXpath("//div[@class='tw-click-outside-layer ax-click-outside-layer']");
            var js = (IJavaScriptExecutor)FrameworkHelper.driver;
            js.ExecuteScript("arguments[0].style.visibility='hidden'", element);
            FrameworkHelper.ClickElementByXpath(addNewTask);
        }

        internal void ClickOpenTask(string name)
        {
            FrameworkHelper.ClickElementByXpath(string.Format(openTask, name));
        }

        internal void CreateNewTask(string _taskListName, string _taskName)
        {
            //ClickCreateNewTaskList();
            SetTaskListName(_taskListName);
            ClickAddNewTask();
            SetTaskDescription(_taskName);
            ClickCreateTaskButton();
            Assert.True(FrameworkHelper.GetElementByXpath(getProjectTitle).Displayed, "Task creation is unsuccessful");
        }

        internal void OpenTask(string tName)
        {
            ClickOpenTask(tName);
            var openTask = FrameworkHelper.GetElementByXpath(openTaskTitle);
            Assert.AreEqual(tName, openTask.Text, "Failed to open task");
        }

        internal void CloseTask()
        {
            FrameworkHelper.ClickElementByXpath(closeTask);
        }

        internal void CompleteTask()
        {
            FrameworkHelper.ClickElementByXpath(completeTaskCheckBox);
            Assert.True(FrameworkHelper.GetElementByXpath(completedTask).Displayed, "Task completion check failed");
        }

        internal void OpenCompletedTask()
        {
            FrameworkHelper.ClickElementByXpath(openCompletedTask);
            Assert.AreEqual("Completed Today", FrameworkHelper.GetElementByXpath(completedTaskStat).Text, "Task is not complete");

        }
    }
}

