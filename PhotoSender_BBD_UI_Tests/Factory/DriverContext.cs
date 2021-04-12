using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace PhotoSender_BBD_UI_Tests.Factory
{
    public interface IDriverContext
    {
        IWebDriver Driver { get; set; }
    }

    public class DriverContext : IDriverContext
    {
        public IWebDriver Driver { get; set;}

        public  DriverContext()
        {
            Driver = GetInstance(BrowserType.Chrome);
        }
        //private static IWebDriver _driver;


        //public static IWebDriver Driver
        //{
        //    get
        //    {
        //        return _driver;
        //    }
        //    set
        //    {
        //        _driver = value;
        //    }
        //}
        

        public static IWebDriver GetInstance(BrowserType browser)
        {
            IWebDriver driver;
            switch (browser)
            {
                case BrowserType.InternetExplorer:
                {
                   driver = new InternetExplorerDriver();
                   return driver;
                }
                
                case BrowserType.FireFox:
                    
                { 
                    driver = new FirefoxDriver();
                    return driver;
                }

                case BrowserType.Chrome:
                {
                    driver = new ChromeDriver();
                    return driver;
                }
            }

            return driver=new ChromeDriver();
        }
    }
}
