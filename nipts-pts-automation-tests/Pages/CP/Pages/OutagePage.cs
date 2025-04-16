using BoDi;
using Defra.UI.Framework.Driver;
using nipts_pts_automation_tests.HelperMethods;
using nipts_pts_automation_tests.Pages.CP.Interfaces;
using OpenQA.Selenium;
using System;

namespace nipts_pts_automation_tests.Pages.CP.Pages
{
    public class OutagePage : IOutagePage
    {
        private readonly IObjectContainer _objectContainer;

        public OutagePage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        #endregion

        #region Methods

        public bool VerifyTheOutageLink(string outageLink)
        {
            string outageLinkEle = $"//a[contains(text(),'{outageLink}')]";
            if (_driver.FindElements(By.XPath(outageLinkEle)).Count > 0)
                return true;
            else 
                return false;  
        }

        public void LoadThe404ErrorPage()
        {
            string url = "https://tst-check-a-pet-from-gb-to-ni.azure.defra.cloud/checker/current-sailingsTest";
            _driver?.Navigate().GoToUrl(url);
        }

        public bool VerifyTextOnPage(string text)
        {
            string outageLinkEle = $"//p[contains(text(),'{text}')]";
            if (_driver.FindElements(By.XPath(outageLinkEle)).Count > 0)
                return true;
            else
                return false;
        }

        public bool VerifyHeadingOnPage(string Heading)
        {
            string outageLinkEle = $"//h1[contains(text(),'{Heading}')]";
            if (_driver.FindElements(By.XPath(outageLinkEle)).Count > 0)
                return true;
            else
                return false;
        }

        #endregion

    }
}
