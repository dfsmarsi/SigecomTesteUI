using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace SigecomTesteUI
{
    public abstract class Page
    {
        protected readonly DriverService DriverService;

        protected Page(DriverService driverService) => DriverService = driverService;

        
    }
}
