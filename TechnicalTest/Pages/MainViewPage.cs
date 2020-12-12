using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Analytics;



namespace TechnicalTest.Pages
{
    public class MainViewPage

    {
        public IWebDriver WebDriver { get; }                    //creates the property of webdriver

        public MainViewPage(IWebDriver webDriver)               //create a constructor , now the webdriver exists. 
        {
            WebDriver = webDriver;                          //Create and initialise property of webdriver
        }

        //Create UI elements
        public IWebElement searchBox => WebDriver.FindElement(By.Id("searchbox"));
        public IWebElement addNewComputerButton => WebDriver.FindElement(By.Id("add"));
        public IWebElement addCancelButton => WebDriver.FindElement(By.XPath(" //*[@id='main']//div//a"));
        public IWebElement addNewComputerHeadingtext => WebDriver.FindElement(By.XPath("//*[@id='main']/h1"));
        public IWebElement existingComputerNameList => WebDriver.FindElement(By.CssSelector("#main > table"));
        public IWebElement createThisComputerButton => WebDriver.FindElement(By.CssSelector("#main > form > div > input"));
        public IWebElement requiredErrorMessageText => WebDriver.FindElement(By.XPath("//*[@id='main']//div/span"));


        private readonly By andNewComputerFieldName = By.XPath("//*[@id='main']//fieldset//div//label");
        public IWebElement computerNameField => WebDriver.FindElement(By.Id("name"));
        public IWebElement successfullyCreatedNewComputerMessage => WebDriver.FindElement(By.XPath("//*[@id='main']/div[1]"));
        public IWebElement GetFieldByLabel (string label) => WebDriver.FindElement(By.XPath($"//form/fieldset/div[label/text()='{label}']/div/input |//form/fieldset/div[label/text()='{label}']/div/select "));
        private readonly By fieldNames = By.XPath("//*[@id='main']//div//label");
        private readonly By fieldTypes = By.XPath("//*[@id='main']//div//div//input | //*[@id='main']//div//div//select");


        public void ClickAddNewComputerButton() => addNewComputerButton.Click();    //lambda experssion to click Add New Computer button 
        public bool IssearchBoxExist() => searchBox.Displayed;                      // lambda expression to check if searchBox present

        public void ClickAddNewCancelButton()                               // Clicks on Cancel Button on the Add New Computer page
        {
            Thread.Sleep(1000);
            addCancelButton.Click();
        }

        public bool CheckExistingComputerListisDisplayed()              // returns if the existing computers name list is displayed
        {
            Thread.Sleep(1000);
            return existingComputerNameList.Displayed;
        }

        public bool IsAddNewComputerPageDisplayed()                 // returns if the Add new computers page is displayed
        {
            Thread.Sleep(1000);
            String text = addNewComputerHeadingtext.Text;
            return text.Equals("Add a computer");
        }

        public string[] GetFeildLabels()             //Gets the list of field labels using the xpath
        {
            return ConvertElementsToText(fieldNames);
        }

        public string[] ConvertElementsToText(By elements)         //converts the list of elements to text
        {
            var itemList = GetAllElements(elements);
            return itemList.Select(i => i.Text).ToArray(); 

        }
        public string[] GetFieldTypes()                 //Gets the list of field types using the xpath
        {
            return ConvertElementsToTagName(fieldTypes); 
        }

        public string[] ConvertElementsToTagName(By elements)   //converts the elements to tagname
        {
            var itemList = GetAllElements(elements);
            return itemList.Select(i => i.TagName).ToArray(); 
        }






        public ReadOnlyCollection<IWebElement> GetAllElements(By locator)
        {
            return WebDriver.FindElements(locator);
        }

        public void ClickCreateThisComputerButton() // Clicks on Cancel Button on the Add New Computer page
        {
            Thread.Sleep(1000);
            createThisComputerButton.Click();
        }

        public bool IsRequiredErrorMessageDisplayed()  // returns required error message
        {
            Thread.Sleep(1000);
            String text = requiredErrorMessageText.Text;
            return text.Equals("Failed to refine type : Predicate isEmpty() did not fail."); 
        }

        public void ClickOnComputerNameFiled() // Clicks on Cancel Button on the Add New Computer page
        {
            Thread.Sleep(1000);
            computerNameField.Click();
        }

        public void EntertheComputerNameFiled() // Clicks on Cancel Button on the Add New Computer page
        {
            Thread.Sleep(1000);
            computerNameField.SendKeys("iPad Air");
        }

        public bool IsSuccessfullyCreatedNewComputerMessageDisplayed()  // returns required error message
        {
            Thread.Sleep(1000);
            String text = successfullyCreatedNewComputerMessage.Text;
            return text.Equals("Done ! Computer Apple Air has been created");
        }

        public void ChangeFieldValue(string label, string value)
        {
            IWebElement field = GetFieldByLabel(label); //get the iwebelement
            field.SendKeys(value);           //sending keys     
        }
    }
}



