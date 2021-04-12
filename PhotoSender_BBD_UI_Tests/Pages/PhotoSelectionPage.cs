using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Extensions;
using PhotoSender_BBD_UI_Tests.Helpers;
using PhotoSender_BBD_UI_Tests.Pages.Locators;

namespace PhotoSender_BBD_UI_Tests.Pages
{
    public interface IPhotoSelectionPage
    {
        IWebElement GetDragAndDropBoxElement();
        ParametersPage ClickNextButton();
        PhotoSelectionPage ClickDragAndDropBox();
        PhotoSelectionPage UploadPictures();
        TPage SwitchContextTo<TPage>();
        void WaitForPageToBeLoaded();
        TPage WaitForPageToBeLoaded<TPage>();
    }

    public class PhotoSelectionPage : BasePage, IPhotoSelectionPage
    {
        string filePath = "\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\53823.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\66550.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\74353.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\144565.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\411820.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\476725.jpg\"";

        private readonly IWebDriver _driver;
        private IFileUploadHelper _fileUploadHelper;

        public PhotoSelectionPage(IWebDriver driver, IFileUploadHelper fileUploadHelper)
        {
            _driver = driver;
            _fileUploadHelper = fileUploadHelper;
        }


        private IList<IWebElement> GetPhotoContainerElements()
        {
            _driver.FluentWaitForElementToBeDisplayed(PhotosSelectionControls.photoContainers);
            return GetElements(PhotosSelectionControls.photoContainers).ToList();
        }

        
        public IWebElement GetDragAndDropBoxElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PhotosSelectionControls.dragAndDropZone);
            return GetElement(PhotosSelectionControls.dragAndDropZone);
        }

        private IWebElement GetNextButtonElement()
        {
            _driver.FluentWaitForElementToBeDisplayed(PhotosSelectionControls.nextButton2);
            return GetElement(PhotosSelectionControls.nextButton);
        }

        public ParametersPage ClickNextButton()
        {
            _driver.FluentWaitForElementToBeClickable(PhotosSelectionControls.nextButton2);
            GetNextButtonElement().Click();
            return SwitchContextTo<ParametersPage>();
        }
        public PhotoSelectionPage ClickDragAndDropBox()
        {
            _driver.FluentWaitForElementToBeClickable(PhotosSelectionControls.dragAndDropZone); 
            GetDragAndDropBoxElement().Click();

            return this;
        }

        public PhotoSelectionPage UploadPictures()
        {
            WaitForPageToBeLoaded();
            ClickDragAndDropBox();
            _fileUploadHelper.AddFile(filePath);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Storage.PhotoCountAdded = GetPhotoContainerElements().Count;
            return this;
        }

    }
}
