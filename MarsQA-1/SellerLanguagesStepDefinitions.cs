using MarsQA_1.SpecflowPages.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1
{
    [Binding]
    public class SellerLanguagesStepDefinitions
    {
        private readonly SellerLanguages _sellerLanguages;

        public SellerLanguagesStepDefinitions()
        {
            _sellerLanguages = new SellerLanguages();
        }

        [Given(@"I navigate to the Languages Section")]
        public void GivenINavigateToTheLanguagesSection()
        {
            _sellerLanguages.ClickLanguageTab();
        }

        [When(@"I add a new '([^']*)'")]
        public void WhenIAddANew(string language)
        {           
            _sellerLanguages.CLickAddNewLanguageBtn();
            _sellerLanguages.SetLanguageName(language);
        }

        [When(@"I select the '([^']*)'")]
        public void WhenISelectThe(string level)
        {

            _sellerLanguages.SetLevel(level);
        }

        [When(@"I save the new language")]
        public void WhenISaveTheNewLanguage()
        {
            _sellerLanguages.AddNewLang();
        }

        [Then(@"The new '([^']*)' should be displayed in the Seller Language List")]
        public void ThenTheNewShouldBeDisplayedInTheSellerLanguageList(string language)
        {
            _sellerLanguages.CheckNewLanguageAdded(language);
        }


        [When(@"I update an existing '([^']*)' to a '([^']*)'")]
        public void WhenIUpdateAnExistingToA(string currentLanguage, string newLanguage)
        {
            _sellerLanguages.EditExistingLanguage(currentLanguage, newLanguage);
        }

        [When(@"I update the Level to a '([^']*)' given the current '([^']*)'")]
        
        public void WhenIUpdateTheLevelToAGivenTheCurrent(string newLevel, string currentLanguage)
        {
            _sellerLanguages.SetNewLevel(currentLanguage,newLevel);
        }

        [When(@"I save the updated '([^']*)'")]
        public void WhenISaveTheUpdated(string currentLanguage)
        {
           _sellerLanguages.CLickUpdateLanguageBtn(currentLanguage);
        }
        
        [Then(@"The updated '([^']*)' should be updated successfully")]
        public void ThenTheUpdatedShouldBeUpdatedSuccessfully(string newLanguage)
        {
            _sellerLanguages.CheckUpdatedLanguage(newLanguage);
        }


        [When(@"I delete an existing '([^']*)'")]
        public void WhenIDeleteAnExisting(string language)
        {
            _sellerLanguages.DeleteLanguage(language);
        }


        [Then(@"The existing '([^']*)' selected should be deleted successfully")]
        public void ThenTheExistingSelectedShouldBeDeletedSuccessfully(string language)
        {
            _sellerLanguages.CheckDeletedLanguage(language);
        }


    }
}
