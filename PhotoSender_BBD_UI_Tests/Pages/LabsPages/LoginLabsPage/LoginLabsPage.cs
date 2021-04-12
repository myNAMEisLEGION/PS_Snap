using PhotoSender_BBD_UI_Tests.Base;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.LoginLabsPage
{

    public class LoginLabsPage : BasePage <ILoginLabsElementMap>, ILoginLabsPage
    {

        public LoginLabsPage LogInToApplication(string userName = null, string password = null)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
               
                WaitForPageToBeLoaded(); 
                _titlePage
                    .ClickLoginToAccountButton()
                    .EnterUserName(userName)
                    .EnterPassword(password);
            }

            return this;
        }

        public string GetAlertText()
        {
            return Element.AlertMessage.Text;
        }
        
        public OverviewPage ClickSubmitButton()
        {
             Element.SubmitButton.Click();
             return SwitchContextTo<OverviewPage>();
        }
        public LoginLabsPage EnterUserName(string userName)
        {
            Element.UserNameField.SendKeys(userName);
            return this;
            
        }
        public LoginLabsPage EnterPassword(string password)
        {
            Element.PasswordField.SendKeys(password);
            return this;
   
        }

    }
}
