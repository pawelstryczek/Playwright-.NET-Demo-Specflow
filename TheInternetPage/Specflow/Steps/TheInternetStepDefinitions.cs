using FluentAssertions;
using TechTalk.SpecFlow;
using TheInternetPage.PageObject;

namespace TheInternetPage.Specflow.Steps
{
    [Binding]
    public class TheInternetStepDefinitions
    {
        //Page Object for TheInternet
        private readonly TheInternet _theInternetPage;
        private CheckboxesPage _checkboxesPage;
        private LoginPage _loginPage;
        private SecureAreaPage _secureAreaPage;

        public TheInternetStepDefinitions(TheInternet theInternetPage)
        {
            _theInternetPage = theInternetPage;
        }

        [Given("anonymous user open TheInternet home page")]
        public void GivenAnonymousOpenTheInternetHomePage()
        {
            _theInternetPage.Open();
        }

        [Given("click checkboxes link")]
        public void GivenClickCheckboxesLink()
        {
            _checkboxesPage = _theInternetPage.ClickCheckboxes();
        }

        [When("checkboxes page is opened select checkbox 1")]
        public void WhenCheckboxesPageIsOpenedSelectCheckbox1()
        {
            _checkboxesPage.SelectCheckboxOne();
        }

        [When("unselect checkbox 2")]
        public void WhenCheckboxesPageIsOpenedUnselectCheckbox2()
        {
            _checkboxesPage.UnSelectCheckboxTwo();
        }

        [Then("verify if checkbox 1 is selected")]
        public void ThenVerifyIfCheckbox1IsSelected()
        {
            _checkboxesPage.IsCheckBoxOneSelected().Should().BeTrue();
        }

        [Then(@"verify if checkbox 2 is unselected")]
        public void ThenVerifyIfCheckboxIsUnselected()
        {
            _checkboxesPage.IsCheckBoxTwoSelected().Should().BeFalse();
        }

        [Given(@"click form authentication link")]
        public void GivenClickFormAuthenticationLink()
        {
            _loginPage = _theInternetPage.ClickFormAuthentication();
        }

        [When(@"page is opened enter username:(.*)")]
        public void WhenPageIsOpenedEnterUsername(string username)
        {
            _loginPage.EnterUsername(username);
        }

        [When(@"enter password:(.*)")]
        public void WhenEnterPassword(string password)
        {
            _loginPage.EnterPassword(password);
        }

        [When(@"click login")]
        public void WhenClickLogin()
        {
            _secureAreaPage = _loginPage.ClickLogin();
        }

        [Then(@"verify if user is logged in")]
        public void ThenVerifyIfUserIsLoggedIn()
        {
            _secureAreaPage.GetLoginStatus().Should().Contain("You logged into a secure area!");
        }

    }
}
