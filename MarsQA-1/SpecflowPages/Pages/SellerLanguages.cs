using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class SellerLanguages
    {
        private IWebElement languageTab => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[1]"));        private IWebElement addNewLanguageBtn => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        private IWebElement languageName => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        private IWebElement levelDropdownBtn => Driver.driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement addLanguageBtn => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        private IWebElement cancelLanguageBtn => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[2]"));
        private IWebElement newlyAddedLanguageName => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));        
        private IWebElement editLanguageBtn => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]"));
        private IWebElement updateLanguageBtn => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]"));

        private IWebElement newLanguageName => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td/div/div[1]/input"));

        
        private IWebElement deleteLanguageBtn => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[2]"));
        private IWebElement successNotification => Driver.driver.FindElement(By.XPath("//div[@class=\"ns-box-inner\"]"));
            
        public void ClickLanguageTab()
        {
            Thread.Sleep(1000);
            languageTab.Click();
        }

        public void CLickAddNewLanguageBtn()
        {
            Thread.Sleep(1000);
            addNewLanguageBtn.Click();           
        }

        public void SetLanguageName(string langName)
        {
            Thread.Sleep(2000);
            languageName.Clear();
            languageName.SendKeys(langName);
        }

        public void SetLevel(string level) 
        {
            Thread.Sleep(1000);
            SelectElement selectedLevel = new SelectElement(levelDropdownBtn);
            selectedLevel.SelectByValue(level);
        }

        public void AddNewLang()
        {
            Thread.Sleep(1000);
            addLanguageBtn.Click();
        }

        public void CheckNewLanguageAdded(string language)
        {
            Thread.Sleep(1000);
            string successMessage = successNotification.Text;
            Assert.That(successMessage.Contains(language + " has been added to your languages"), "Language was not deleted successfully");
            //Assert.That(newlyAddedLanguageName.Text == language, "New language not added");

        }

        private IWebElement EditLanguage(string language) => Driver.driver.FindElement(By.XPath("//td[text()='" + language + "']/following::td[2]/descendant::i[@class=\"outline write icon\"]"));
        private IWebElement EditLanguageName(string language) => Driver.driver.FindElement(By.XPath("//input[@value='"+language+"']"));
        private IWebElement EditLevelDropdownBtn(string language) => Driver.driver.FindElement(By.XPath("//input[@value='"+language+"']/following::select[@name='level']"));
        private IWebElement UpdateLanguageBtn(string language) => Driver.driver.FindElement(By.XPath("//input[@value='"+ language +"']/following::span[@class=\"buttons-wrapper\"]/descendant::INPUT[@value=\"Update\"]"));
        
        public void EditExistingLanguage(string currentLanguage, string newLanguage)
        {
            Thread.Sleep(1000);
            var editLanguage = EditLanguage(currentLanguage);
            editLanguage.Click();
            Thread.Sleep(2000);
            var editLanguageName = EditLanguageName(currentLanguage);
            editLanguageName.Clear();
            editLanguageName.SendKeys(newLanguage);            
        }
          
        

        public void SetNewLevel(string currentLanguage, string newLevel)
        {
            Thread.Sleep(1000);
            var editLevelDropdownBtn = EditLevelDropdownBtn(currentLanguage);
            SelectElement selectedLevel = new SelectElement(editLevelDropdownBtn);
            selectedLevel.SelectByValue(newLevel);
        }

        public void CLickUpdateLanguageBtn(string currentLanguage)
        {
            var updateLanguageBtn = UpdateLanguageBtn(currentLanguage);
            Thread.Sleep(1000);
            updateLanguageBtn.Click();
        }

        public void CheckUpdatedLanguage(string newLanguage)
        {
            Thread.Sleep(1000);
            string successMessage = successNotification.Text;
            Assert.That(successMessage.Contains(newLanguage + " has been updated to your languages"), "Language was not updated successfully");           
        }

        private IWebElement RemoveLanguage(string language) => Driver.driver.FindElement(By.XPath("//td[text()='" + language + "']/following::td[2]/descendant::i[@class=\"remove icon\"]"));

        public void DeleteLanguage(string language)
        {
            Thread.Sleep(1000);
            var removeLanguage = RemoveLanguage(language);
            removeLanguage.Click();
        }

        public void CheckDeletedLanguage(string language)
        {
            Thread.Sleep(1000);
            string successMessage = successNotification.Text;
            Assert.That(successMessage.Contains(language + " has been deleted from your languages"), "Language was not deleted successfully");
        }


        
    }
}
