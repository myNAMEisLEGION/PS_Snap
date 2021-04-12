using PhotoSender_BBD_UI_Tests.Base;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.LoginLabPage
{
    public class LabClientLoginPage : BasePage<ILabClientLoginPageElementMap>, ILabClientLoginPage
    {
        public LabClientLoginPage EnterCredentialsLabClientLoginPage(string username=null, string password=null)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                WaitForPageToBeLoaded();
                Element.UserNameField.SendKeys(username);
                Element.PasswordField.SendKeys(password);
                Element.SubmitButton.Click();
                LabsGpi.ClickMenuOption();
            }

            return this;
        }

        public ILabClientLoginPage Login { get; set; }
    }
}