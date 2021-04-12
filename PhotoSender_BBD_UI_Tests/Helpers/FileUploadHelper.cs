using AutoIt;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;


namespace PhotoSender_BBD_UI_Tests.Helpers
{
    public interface IFileUploadHelper
    {
        void AddFile(string filePath);
    }

    public class FileUploadHelper : IFileUploadHelper
    {
        string filePath = "\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\53823.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\66550.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\74353.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\144565.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\411820.jpg\"\"C:\\Users\\marci\\OneDrive\\Desktop\\TESTING\\Photosender\\FullHD\\476725.jpg\"";

        AutoItX3 auto = new AutoItX3();

        public void AddFile(string filePath)
        {
            auto.ControlFocus("Otwieranie", "", "Edit1");
            auto.Sleep(2000);
            auto.ControlSetText("Otwieranie", "", "Edit1", filePath);
            auto.ControlClick("Otwieranie", "", "Button1");
        }

    }
}
