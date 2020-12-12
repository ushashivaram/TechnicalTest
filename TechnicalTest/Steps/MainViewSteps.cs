using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechnicalTest.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static TechnicalTest.Pages.MainViewPage;



namespace TechnicalTest.Steps 
{
    [Binding] //Binds the steps to feature file

    public sealed class MainViewSteps

    {

        MainViewPage mainViewPage = null; //creates Anti-Context Injection code

        [Given(@"that I navigate to the computer database app")]  //opens the browser navigates to URL
        public void GivenThatINavigateToTheComputerDatabaseApp()
        {
            IWebDriver webDriver = new ChromeDriver(); //create object of the chrome driver
            webDriver.Navigate().GoToUrl("http://computer-database.gatling.io/computers"); //navigates to the URL
            mainViewPage = new MainViewPage(webDriver); // passing the webdriver to Main view page which we declared  
        }

        [Then(@"I am in the Main View page")]     //  Checks if filter box /search box is present
        public void ThenIAmInTheMainViewPage()
        {
            Assert.IsTrue(mainViewPage.IssearchBoxExist()); 
        }

        [Then(@"I see list of the existing computers present in the database")]  //  Check if Existing Computer List is Displayed
        public void ThenISeeListOfTheExistingComputersPresentInTheDatabase()
        {
            Assert.IsTrue(mainViewPage.CheckExistingComputerListisDisplayed()); 
        }

        [When(@"I click  on the Add a new computer button")]    // Clicks on Add New Computer Button
        public void WhenIClickOnTheAddANewComputerButton()
        {
            mainViewPage.ClickAddNewComputerButton(); 
        }

        [Then(@"I am in the Add a computer page")]        //Checks if I am on the Add New computer page
        public void ThenIAmInTheAddAComputerPage()
        {
            Assert.IsTrue(mainViewPage.IsAddNewComputerPageDisplayed());
        }

        [When(@"I click on Cancel button on the Add a new computer page")] //clicks on cancel button
        public void WhenIClickOnCancelButtonOnTheAddANewComputerPage()
        {
            mainViewPage.ClickAddNewCancelButton(); 
        }

        [Then(@"I should see four fields")]
        public void ThenIShouldSeeFourFields(Table table)     
        {
            string[] fieldLabels = mainViewPage.GetFeildLabels();               // gets a list of field names using xpaths
            string[] fieldTypes = mainViewPage.GetFieldTypes();                 // gets a list of field types using xpaths
            string[] labels = table.Rows.Select(r => r.Values.ToList().FirstOrDefault()).ToArray();  // gets all the field names  from the first column
            string[] types = table.Rows.Select(r => r.Values.ToList()[1]).ToArray();                // gets all the field tyes  from the second  column
            Assert.IsTrue(labels.SequenceEqual(fieldLabels), " field label do not match");  
            Assert.IsTrue(types.SequenceEqual(fieldTypes), " field  types do not match");
        }

        [When(@"I click on Create this computer button")]     //Clicks  this computer button
        public void WhenIClickOnCreateThisComputerButton()
        {
            mainViewPage.ClickCreateThisComputerButton();
        }

        [Then(@"I see required error message")]         //required error message
        public void ThenISeeRequiredErrorMessage()
        {
            Assert.IsTrue(mainViewPage.IsRequiredErrorMessageDisplayed());
        }

      
        [Then(@"I should see success message")]       // checks if new computer is  successfully added 
        public void ThenIShouldSeeSuccessMessage()
        {
            Assert.IsTrue(mainViewPage.IsSuccessfullyCreatedNewComputerMessageDisplayed());
        }

        [Then(@"I edit the following fields")]      // enters the field value into the respective fields
        public void ThenIEditTheFollowingFields(Table table)
        {
            foreach (TableRow row in table.Rows)
            {
                string field = row.Values.ToList().FirstOrDefault();    //getting he first entry in the list of values(field column from feature file)
                string value = row.Values.ElementAtOrDefault(1);        // gets the second value in the list of entries(values column from feature file)
                mainViewPage.ChangeFieldValue(field, value);         //passes the value to the method
            }
        }






    }




}




