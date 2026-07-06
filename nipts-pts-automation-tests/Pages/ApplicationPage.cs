using Reqnroll.BoDi;
using OpenQA.Selenium;
using nipts_pts_automation_tests.Configuration;
using nipts_pts_automation_tests.HelperMethods;


namespace nipts_pts_automation_tests.Pages
{
    public class ApplicationPage : IApplicationPage
    {
        private string Platform => ConfigSetup.BaseConfiguration.TestConfiguration.Platform;
        private IObjectContainer _objectContainer;

        #region Page Objects

        private IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-heading-xl')] | //h1[@class='govuk-label-wrapper'] | //h1[@class='govuk-fieldset__heading'] | //h1[@class='govuk-panel__title']"));
        private By Englishclick => By.XPath("//a[contains(@id,'localeEn')] | //span[text()='English']");
        private By Welshclick =By.XPath("//a[contains(@id,'localeCy')] | //span[contains(text(),'Cymraeg')]");
        private IWebElement ApplyForADocEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Apply for a document')] | //button[contains(text(),'Gwneud cais am ddogfen')]"));
        private IWebElement ContinueWelshEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Parhau')] | //button[contains(text(),'Continue')]"));
        private IWebElement BackWelshEle => _driver.WaitForElement(By.XPath("//a[contains(text(),'Yn ôl')]"));
        private IWebElement ErrorMessageEle => _driver.WaitForElement(By.XPath("//ul[contains(@class,'govuk-error-summary__list')]//a | //ul[contains(@class,'govuk-error-summary__list')]//span"));
        private IWebElement LinkLanguageSelector => _driver.WaitForElement(By.XPath("(//a[contains(@id,'locale')]//span[1]"));
        public IWebElement lnkManageAccount => _driver.WaitForElement(By.XPath("//a[@href='/User/ManageAccount']"));
        public IWebElement lnkManageYourAccount => _driver.WaitForElement(By.XPath("//a[@href='/User/RedirectToExternal']"));
        public IWebElement lnkViewDocsFromManageAcc => _driver.WaitForElement(By.XPath("//a[normalize-space(text()) ='Gweld eich dogfennau teithio gydol oes i anifeiliaid anwes neu wneud cais am un newydd.']"));
        private IWebElement ContinueEle => _driver.WaitForElement(By.XPath("//button[contains(text(),'Continue')]"));
        private IWebElement tableBody => _driver.WaitForElement(By.XPath("//table/tbody"));
        private IWebElement HelpWelshEle => _driver.WaitForElement(By.XPath("//a[contains(text(),'Cael help')]"));
        private IWebElement PlaceOfIssuanceEle => _driver.WaitForElement(By.XPath("(//h2[contains(@class,'govuk-summary-card__title')])[5]"));
        private IReadOnlyCollection<IWebElement> divMicrochipInformationActionList => _driver.WaitForElements(By.XPath("//div[@id='document-microchip-card']//dl/div/descendant::dd[2]/a"));
        private IReadOnlyCollection<IWebElement> divPetDetailsActionList => _driver.WaitForElements(By.XPath("//div[@id='document-pet-card']//dl/div/descendant::dd[2]/a"));
        private IReadOnlyCollection<IWebElement> divPetOwnerDetailsActionList => _driver.WaitForElements(By.XPath("//div[@id='document-owner-card']//dl/div/descendant::dd[2]/a"));
        private IWebElement WELSHPTDNumberEle => _driver.WaitForElement(By.XPath("//dt[contains(text(),'Rhif y ddogfen deithio i anifail anwes')]/following-sibling::dd"));
        #endregion Page Objects

        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();

        public ApplicationPage(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page Methods

        public bool VerifyNextPageIsLoaded(string pageName)
        {
            string text = PageHeading.Text;
            return PageHeading.Text.Contains(pageName);
        }

        public void ClickOnWelshLang()
        {
            if (_driver.WaitForElements(Welshclick).Count > 0)
            {
                _driver.WaitForElement(Welshclick).Click();
            }
        }

        public void ClickOnEnglishLang()
        {
            if (_driver.WaitForElements(Englishclick).Count > 0)
            {
                _driver.WaitForElement(Englishclick).Click();
            }
        }

        public void ClickOnApplyForADocument()
        {
            ApplyForADocEle.Click();
        }

        public void ClickOnContinueWelsh()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", ContinueWelshEle);
            //ContinueWelshEle.Click();
        }

        public void ClickOnBackWelsh()
        {
            BackWelshEle.Click();
        }

        public void SwitchToPreviousOpenTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
        }

        public void SwitchToNextTab()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.LastOrDefault());
            Thread.Sleep(1000);
        }

        public void ClickBrowserBack()
        {
            _driver.Navigate().Back();
        }

        public void CloseCurrentTab()
        {
            _driver.Close();
        }

        public bool VerifyErrorMessage(string errorMessage)
        {
            return ErrorMessageEle.Text.Contains(errorMessage);
        }

        public void ClickOnManageAccountLink()
        {
            lnkManageAccount.Click();
        }

        public void ClickOnManageYourAccountLink()
        {
            lnkManageYourAccount.Click();
        }

        public void ClickOnViewYourPetTravelDoc()
        {
            lnkViewDocsFromManageAcc.Click();
        }

        public bool VerifyLanguageAtPageFooter(string displayedLang)
        {
            By EnglishLinkLanguageSelector = By.XPath("//a[contains(@id,'localeEn')]");
            By WelshLinkLanguageSelector = By.XPath("//a[contains(@id,'localeCy')]");
            bool status = false; 
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;

            if (displayedLang.Equals("English"))
            {
                if (_driver.FindElements(EnglishLinkLanguageSelector).Count > 0)
                    status = true;
            }
            if (displayedLang.Equals("Cymraeg"))
            {
                if (_driver.FindElements(WelshLinkLanguageSelector).Count > 0)
                    status = true;
            }
            return status;
        }

        public void ClickOnContinueEng()
        {
            ContinueEle.Click();
        }

        public bool VerifyTheExpectedStatus(string petName, string status)
        {
            // Status transitions (e.g. Pending -> Approved) are driven by an asynchronous backend
            // process (a Service Bus message consumed and written back to Dynamics), so the new
            // status is not visible immediately. Poll by refreshing and re-checking until the
            // expected status appears or the timeout elapses, rather than checking only once.
            var timeout = TimeSpan.FromMinutes(6);
            var pollInterval = TimeSpan.FromSeconds(5);
            var deadline = DateTime.UtcNow + timeout;
            string? lastSeenStatus = null;
            var attempts = 0;

            Console.WriteLine($"=== POLLING FOR STATUS '{status}' (pet '{petName}', timeout {timeout.TotalMinutes} min) ===");

            do
            {
                attempts++;
                Thread.Sleep(pollInterval);
                _driver.Navigate().Refresh();

                try
                {
                    lastSeenStatus = GetDisplayedStatus(petName);
                    if (lastSeenStatus != null && lastSeenStatus.Trim().ToUpper().Contains(status.ToUpper()))
                    {
                        Console.WriteLine($"=== STATUS '{status}' matched after {attempts} attempt(s) (saw '{lastSeenStatus.Trim()}') ===");
                        return true;
                    }
                }
                catch (Exception ex) when (ex is StaleElementReferenceException || ex is NoSuchElementException)
                {
                    // Table can be re-rendering after the refresh; treat as "not ready yet" and
                    // re-check on the next poll iteration instead of aborting the whole wait.
                }
                catch (WebDriverException ex)
                {
                    // A slow/degraded BrowserStack session can make a single WebDriver command block
                    // for the full command timeout (~90s) or drop the connection. Treat it as a
                    // transient "not ready yet" so one bad command does not fail the whole test; the
                    // 6 min deadline still bounds the total wait.
                    Console.WriteLine($"=== STATUS POLL: transient WebDriver error on attempt {attempts} ({ex.GetType().Name}: {ex.Message}); retrying ===");
                }
            }
            while (DateTime.UtcNow < deadline);

            Console.WriteLine($"=== STATUS POLL TIMED OUT after {attempts} attempt(s) (~{timeout.TotalMinutes} min). " +
                              $"Expected '{status}' but last saw '{lastSeenStatus?.Trim() ?? "<row/status not found>"}' ===");
            return false;
        }

        private string? GetDisplayedStatus(string petName)
        {
            // Locate the status cell for this pet with a single XPath rather than iterating every
            // row and issuing a child FindElement per row. On a degraded BrowserStack session each
            // WebDriver command can block for the full command timeout (~90s), so a per-row loop
            // could cost (rows x 90s) per poll and overshoot the deadline by tens of minutes. Using
            // FindElements (which returns empty instead of throwing) keeps each poll to one command.
            var statusPath = $"//tr//th[contains(text(),'{petName}')]/../td[1]/strong";
            var cells = _driver.FindElements(By.XPath(statusPath));
            return cells.Count > 0 ? cells[0].Text : null;
        }

        public void ClickOnHelpWelshLink()
        {
            HelpWelshEle.Click();
        }

        public bool VerifyWELSHApprovedPTD(string fieldName, string fieldValue)
        {
            string FieldName = "//dt[contains(text(),'" + fieldName + "')]";
            string FieldValue = "//dt[contains(text(),'" + fieldName + "')]/..//dd";

            if (_driver.WaitForElement(By.XPath(FieldName)).Text.Contains(fieldName) && _driver.WaitForElement(By.XPath(FieldValue)).Text.Contains(fieldValue)); 
            {
                return true;
            }    

        }

        public bool VerifyPTDNumberOnApprovedPTD(string ptdNumber , string ptdNumberValue) 
        {
            string PTDNumber = "//dt[contains(text(),'" + ptdNumber + "')]";
            string PTDNumberValue = "//dt[contains(text(),'" + ptdNumber + "')]/..//dd";

            if (_driver.FindElement(By.XPath(PTDNumber)).Text.Contains(ptdNumber) && _driver.FindElement(By.XPath(PTDNumberValue)).Text.Contains(ptdNumberValue));
            {
                return true;
            }
        }

        public bool VerifyMichrochipDateOnApprovedPTD(string michrochipDate, string michrochipDateValue)
        {
            string MichrochipDate = "//dt[contains(text(),'" + michrochipDate + "')]";
            string MichochipDateValue = "//dt[contains(text(),'" + michrochipDate + "')]/..//dd";

            if (_driver.FindElement(By.XPath(MichrochipDate)).Text.Contains(michrochipDate) && _driver.FindElement(By.XPath(MichochipDateValue)).Text.Contains(michrochipDateValue)) ;
            {
                return true;
            }
        }

        public bool VerifyPetDOBOnApprovedPTD(string petDOB, string petDOBValue)
        {
            string PetDOB = "//dt[contains(text(),'" + petDOB + "')]";
            string PetDOBValue = "//dt[contains(text(),'" + petDOB + "')]/..//dd";

            if (_driver.FindElement(By.XPath(PetDOB)).Text.Contains(petDOB) && _driver.FindElement(By.XPath(PetDOBValue)).Text.Contains(petDOBValue)) ;
            {
                return true;
            }
        }



        #endregion Page Methods

        public void ClickWelshMicrochipChangeLink(string fieldName)
        {
            switch (fieldName)
            {
                case "Rhif y microsglodyn":
                    divMicrochipInformationActionList.ElementAt(0)?.Click();
                    break;
                case "Dyddiad mewnblannu neu sganio":
                    divMicrochipInformationActionList.ElementAt(1)?.Click();
                    break;
            }
        }

        public void ClickWelshPetDetailsChangeLink(string fieldName)
        {
            switch (fieldName)
            {
                case "Enw":
                    divPetDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "Rhywogaeth":
                    divPetDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "Brid":
                    divPetDetailsActionList.ElementAt(2)?.Click();
                    break;
                case "Rhyw":
                    divPetDetailsActionList.ElementAt(3)?.Click();
                    break;
                case "Dyddiad geni":
                    divPetDetailsActionList.ElementAt(4)?.Click();
                    break;
                case "Lliw":
                    divPetDetailsActionList.ElementAt(5)?.Click();
                    break;
                case "Nodweddion arwyddocaol":
                    divPetDetailsActionList.ElementAt(6)?.Click();
                    break;
            }
        }

        public void ClickWelshPetDetailsChangeForFerretLink(string fieldName)
        {
            switch (fieldName)
            {
                case "Enw":
                    divPetDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "Rhywogaeth":
                    divPetDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "Rhyw":
                    divPetDetailsActionList.ElementAt(2)?.Click();
                    break;
                case "Dyddiad geni":
                    divPetDetailsActionList.ElementAt(3)?.Click();
                    break;
                case "Lliw":
                    divPetDetailsActionList.ElementAt(4)?.Click();
                    break;
                case "Nodweddion arwyddocaol":
                    divPetDetailsActionList.ElementAt(5)?.Click();
                    break;
            }
        }

        public void ClickWelshPetOwnerChangeLink(string fieldName)
        {
            switch (fieldName)
            {
                case "Enw":
                    divPetOwnerDetailsActionList.ElementAt(0)?.Click();
                    break;
                case "Cyfeiriad":
                    divPetOwnerDetailsActionList.ElementAt(1)?.Click();
                    break;
                case "Rhif ff":
                    divPetOwnerDetailsActionList.ElementAt(2)?.Click();
                    break;
            }
        }

        public bool? VerifyWELSHFieldsAndValuesForPendingAppl(string fieldName, string fieldValue)
        {
            string FieldName = "//dt[contains(text(),'" + fieldName + "')]";
            string FieldValue = "//dt[contains(text(),'" + fieldName + "')]/..//dd";

            if (_driver.WaitForElement(By.XPath(FieldName)).Text.Contains(fieldName) && _driver.WaitForElement(By.XPath(FieldValue)).Text.Contains(fieldValue)) ;
            {
                return true;
            }
        }

        public bool? VerifyReferenceNumberOnPendingAppl(string referenceNumberText, string referenceNumberValue)
        {
            string ReferenceNumberText = "//dt[contains(text(),'" + referenceNumberText + "')]";
            string ReferenceNumberValue = "//dt[contains(text(),'" + referenceNumberText + "')]/..//dd";

            if (_driver.FindElement(By.XPath(ReferenceNumberText)).Text.Contains(referenceNumberText) && _driver.FindElement(By.XPath(ReferenceNumberValue)).Text.Contains(referenceNumberValue)) ;
            {
                return true;
            }
        }

        public bool? VerifyMichrochipDateOnPendingAppl(string michrochipDateText, string michrochipDateValue)
        {
            string MichrochipDate = "//dt[contains(text(),'" + michrochipDateText + "')]";
            string MichochipDateValue = "//dt[contains(text(),'" + michrochipDateText + "')]/..//dd";

            if (_driver.FindElement(By.XPath(MichrochipDate)).Text.Contains(michrochipDateText) && _driver.FindElement(By.XPath(MichochipDateValue)).Text.Contains(michrochipDateValue)) ;
            {
                return true;
            }
        }

        public bool? VerifyPetDOBOnPendingAppl(string petDOBText, string petDOBValue)
        {
            string PetDOB = "//dt[contains(text(),'" + petDOBText + "')]";
            string PetDOBValue = "//dt[contains(text(),'" + petDOBText + "')]/..//dd";

            if (_driver.FindElement(By.XPath(PetDOB)).Text.Contains(petDOBText) && _driver.FindElement(By.XPath(PetDOBValue)).Text.Contains(petDOBValue)) ;
            {
                return true;
            }
        }

        public bool? VerifyHeadingTextOnSummaryPage(string heading)
        {
            string headingPath = $"//h2[contains(text(),'{heading}')]";
            if (_driver.FindElements(By.XPath(headingPath)).Count > 0)
                return true;
            else 
                return false;
        }


        public bool VerifyWELSHPTDNoOnSearchResultsPassFailPage(string finalPTD)
        {
            return WELSHPTDNumberEle.Text.Equals(finalPTD);
        }
        
        public bool VerifyPlaceOfIssuanceOnApprovedDoc(string placeofIssText)
        {
            return PlaceOfIssuanceEle.Text.Contains(placeofIssText);
        }
    }
}
