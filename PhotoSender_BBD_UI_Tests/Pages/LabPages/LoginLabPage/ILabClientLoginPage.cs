using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSender_BBD_UI_Tests.Base;
using PhotoSender_BBD_UI_Tests.Pages.LabsPages.GPI;

namespace PhotoSender_BBD_UI_Tests.Pages.LabPages.LoginLabPage
{
    public interface ILabClientLoginPage
    {
        LabClientLoginPage EnterCredentialsLabClientLoginPage(string username = null, string password = null);
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
        ILabClientLoginPage Login { get; set; }
        ILabsGPI LabsGpi { get; set; }
    }
}
