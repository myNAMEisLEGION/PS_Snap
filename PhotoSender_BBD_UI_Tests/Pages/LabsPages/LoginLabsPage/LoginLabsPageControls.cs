using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.LoginLabsPage
{
    public static class LoginLabsPageControls
    {
        public static class XPath
        {
            public static readonly string fieldUserName = "//input[@type='text']";

            public static readonly string fieldPassword = "//input[@type='password']";

            public static readonly string SubmitButton = "//button[@type='submit']";

            public static readonly string btnLoginLink = "//a[@class='menu-link']";

            public static readonly string alertMessage = "//span[@class='alert-text']";
        }

        public static class Id
        {

        }

    }
}
