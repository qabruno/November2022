﻿

namespace November2022.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // click on Create New button
            Thread.Sleep(1500);
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();
            Thread.Sleep(500);

            Wait.WaitForElementToExist(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 6);

            // select Time in the typecode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();

            // enter code in the code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("November2022");

            // enter description in the description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("November2022");

            // enter price in price per unit textbox
            IWebElement overlappingTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            overlappingTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            // click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            Wait.WaitForElementToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 12);

            // check if new time record has been created successfully
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            // Example 1:
            Assert.That(newCode.Text == "November2022", "Actual code and expected code do not match.");
            Assert.That(newDescription.Text == "November2022", "Actual description and expected description do not match");
            Assert.That(newPrice.Text == "$12.00", "Actual price and expeected price do not match.");

            // Example 2:
            //if (newCode.Text == "November2022")
            //{
            //    Assert.Pass("Time record created successfully.");
            //}
            //else
            //{
            //    Assert.Fail("Time record hasn't been created successfully");
            //}
        }

        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement findNewRecordCreated = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findNewRecordCreated.Text == "November2022")
            {
                Thread.Sleep(2000);
                // click edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited");
            }
            // edit code textbox 
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("C002");
            Thread.Sleep(1500);

            // edit description textbox
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys("Firstone");
            Thread.Sleep(1500);

            // edit price per unit textbox
            IWebElement overlappingTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement pricePerUnitTextbox = driver.FindElement(By.Id("Price"));

            overlappingTag.Click();
            pricePerUnitTextbox.Clear();
            overlappingTag.Click();
            pricePerUnitTextbox.SendKeys("200");

            // click save button
            IWebElement clickSavebutton = driver.FindElement(By.Id("SaveButton"));
            clickSavebutton.Click();
            Thread.Sleep(1500);

            // click go to the late page
            IWebElement gotothelastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotothelastpageButton.Click();
            Thread.Sleep(1500);

        }

        public void DeleteTM(IWebDriver driver)
        {
            Thread.Sleep(3000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            // click delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(1500);

            // conforming delete ok button
            driver.SwitchTo().Alert().Accept();


        }
    }
}
