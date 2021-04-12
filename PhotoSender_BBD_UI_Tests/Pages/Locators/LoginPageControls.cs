using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSender_BBD_UI_Tests.Pages.Locators
{
    class LoginPageControls
    {
        public static readonly string fieldUserName = "//input[@type='text']";

        public static readonly string fieldPassword = "//input[@type='password']";

        public static readonly string logInButton = "//button[@type='submit']";

        public static readonly string btnLoginLink = "//a[@class='menu-link']";

        public static readonly string alertMessage = "//span[@class='alert-text']";
    }
}
