using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PhotoSender_BBD_UI_Tests.Pages.LabsPages.LoginLabsPage
{
    public static class LoginLabsAsserter
    {
        public static void AssertResultsCountIsAsExpected(this LoginLabsPage page, int expectedCount)
        {
            Assert.AreEqual( expectedCount, "The results count is not as expected.");
        }
    }
}
