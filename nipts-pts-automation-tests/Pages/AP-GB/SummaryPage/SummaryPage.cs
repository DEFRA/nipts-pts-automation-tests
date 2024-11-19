using BoDi;
using Defra.UI.Tests.Contracts;
using nipts_pts_automation_tests.HelperMethods;
using OpenQA.Selenium;

namespace nipts_pts_automation_tests.Pages.AP_GB.SummaryPage
{
    public class SummaryPage : ISummaryPage
    {
        private readonly IObjectContainer _objectContainer;

        public SummaryPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[@class='govuk-heading-xl']"), true);
        private IReadOnlyCollection<IWebElement> divDocumentIssueDetails => _driver.WaitForElements(By.XPath("//div[@id='document-issued-card']//dl/div"));
        private IReadOnlyCollection<IWebElement> divDocumentIssue => _driver.WaitForElements(By.XPath("//div[@id='document-issued-card']//dl/div"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformation => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div"));
        private IReadOnlyCollection<IWebElement> divPetDetails => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetails => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div"));
        private IWebElement lnkPDFDownload => _driver.WaitForElement(By.XPath("//a[contains(text(),'Download your application')]"));
        private IWebElement lnkPrint => _driver.WaitForElement(By.XPath("//a[contains(text(),'Print your application')]"));
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            return PageHeading.Text.Contains(pageTitle);
        }

        public void ClickPDFDownloadLink()
        {
            lnkPDFDownload.Click();
        }

        public bool ClickPrintdLink()
        {
            //lnkPrint.Click();
            return true;
        }

        public Summary GetSummaryDetails()
        {
            var summary = new Summary();
            try
            {
                foreach (var element in divDocumentIssue)
                {
                    var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                    var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                    switch (elementTitle)
                    {
                        case "PET TRAVEL DOCUMENT NUMBER":
                            summary.PTDNumber = elementValue;
                            break;
                        case "DATE":
                            summary.Date = elementValue;
                            break;
                    }
                }
            }
            catch
            {

            }


            foreach (var element in divDocumentIssueDetails)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "REFERENCE NUMBER":
                        summary.ReferenceNumber = elementValue;
                        break;
                    case "DATE":
                        summary.Date = elementValue;
                        break;
                }
            }

            foreach (var element in divMicrochipInformation)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "MICROCHIP NUMBER":
                        summary.MicrochipNumber = elementValue;
                        break;
                    case "IMPLANT OR SCAN DATE":
                        summary.ImplantOrScanDate = elementValue;
                        break;
                }
            }

            foreach (var element in divPetDetails)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "NAME":
                        summary.PetName = elementValue;
                        break;
                    case "SPECIES":
                        summary.Species = elementValue;
                        break;
                    case "BREED":
                        summary.Breed = elementValue;
                        break;
                    case "SEX":
                        summary.Sex = elementValue;
                        break;
                    case "DATE OF BIRTH":
                        summary.DateOfBirth = elementValue;
                        break;
                    case "COLOUR":
                        summary.Colour = elementValue;
                        break;
                    case "SIGNIFICANT FEATURES":
                        summary.SignificantFeatures = elementValue;
                        break;
                }
            }

            foreach (var element in divPetOwnerDetails)
            {
                var elementTitle = element.FindElement(By.TagName("dt"))?.Text?.Replace("\r\n", string.Empty).Trim()?.ToUpper();
                var elementValue = element.FindElements(By.TagName("dd"))?[0].Text?.Replace("\r\n", string.Empty).Trim();

                switch (elementTitle)
                {
                    case "NAME":
                        summary.Name = elementValue;
                        break;
                    case "ADDRESS":
                        summary.Address = elementValue;
                        break;
                    case "PHONE NUMBER":
                        summary.PhoneNumber = elementValue;
                        break;
                    case "EMAIL":
                        summary.Email = elementValue;
                        break;
                }
            }

            return summary;
        }
    }
}
#endregion