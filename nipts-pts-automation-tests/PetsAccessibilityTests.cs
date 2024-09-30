using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Axe;


namespace nipts_pts_automation_tests
{
    public class PetsAccessibilityTests
        
    {
        private IWebDriver _driver;
        public PetsAccessibilityTests()
        { }

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void TravelDocumentTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "TravelDocumentTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void ManageAccountTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//a[@href='/User/ManageAccount']")).Click();
            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "ManageAccountTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [Test]
        public void AccessibilityStatementTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//a[@href='/Content/AccessibilityStatement']")).Click();
            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "AccessibilityStatementTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [Test]
        public void CookiesTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//a[@href='/Content/Cookies']")).Click();
            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "CookiesTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [Test]
        public void TermsAndConditionsTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//a[@href='/Content/TermsAndConditions']")).Click();
            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "TermsAndConditionsTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }


        [Test]
        public void PetKeeperUserDetailsTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();

            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetKeeperUserDetailsTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void PetKeeperNameTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345"); Thread.Sleep(1000);
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetKeeperNameTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void PetKeeperPostcodeTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//button[contains(text(),'Find address')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetKeeperPostcodeTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void PetKeeperAddressManualTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetKeeperAddressManualTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void PetKeeperPhoneTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetKeeperPhoneTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void PetMicrochipNotAvailableTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetMicrochipNotAvailableTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }
        [Test]
        public void PetMicrochipDateTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetMicrochipDateTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void PetSpeciesTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetSpeciesTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);

        }

        [Test]
        public void PetBreedTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel2 = _driver.FindElement(By.XPath($"//label[contains(.,'Cat')]"));
            IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)_driver;
            jsExecutor2.ExecuteScript("arguments[0].click();", commLabel2);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetBreedTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }


        [Test]
        public void PetNameTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel2 = _driver.FindElement(By.XPath($"//label[contains(.,'Cat')]"));
            IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)_driver;
            jsExecutor2.ExecuteScript("arguments[0].click();", commLabel2);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("BreedId")).SendKeys("TestBreed");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetNameTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [Test]
        public void PetGenderTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel2 = _driver.FindElement(By.XPath($"//label[contains(.,'Cat')]"));
            IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)_driver;
            jsExecutor2.ExecuteScript("arguments[0].click();", commLabel2);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("BreedId")).SendKeys("TestBreed");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("PetName")).SendKeys("PetName");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetGenderTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }


        [Test]
        public void PetAgeTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel2 = _driver.FindElement(By.XPath($"//label[contains(.,'Cat')]"));
            IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)_driver;
            jsExecutor2.ExecuteScript("arguments[0].click();", commLabel2);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("BreedId")).SendKeys("TestBreed");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("PetName")).SendKeys("PetName");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel3 = _driver.FindElement(By.XPath($"//label[contains(.,'Female')]"));
            IJavaScriptExecutor jsExecutor3 = (IJavaScriptExecutor)_driver;
            jsExecutor3.ExecuteScript("arguments[0].click();", commLabel3);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetAgeTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }


        [Test]
        public void PetColourTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel2 = _driver.FindElement(By.XPath($"//label[contains(.,'Cat')]"));
            IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)_driver;
            jsExecutor2.ExecuteScript("arguments[0].click();", commLabel2);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("BreedId")).SendKeys("TestBreed");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("PetName")).SendKeys("PetName");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel3 = _driver.FindElement(By.XPath($"//label[contains(.,'Female')]"));
            IJavaScriptExecutor jsExecutor3 = (IJavaScriptExecutor)_driver;
            jsExecutor3.ExecuteScript("arguments[0].click();", commLabel3);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2023");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetColourTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [Test]
        public void PetFeatureTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel2 = _driver.FindElement(By.XPath($"//label[contains(.,'Cat')]"));
            IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)_driver;
            jsExecutor2.ExecuteScript("arguments[0].click();", commLabel2);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("BreedId")).SendKeys("TestBreed");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("PetName")).SendKeys("PetName");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel3 = _driver.FindElement(By.XPath($"//label[contains(.,'Female')]"));
            IJavaScriptExecutor jsExecutor3 = (IJavaScriptExecutor)_driver;
            jsExecutor3.ExecuteScript("arguments[0].click();", commLabel3);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2023");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel4 = _driver.FindElement(By.XPath($"//label[contains(.,'White')]"));
            IJavaScriptExecutor jsExecutor4 = (IJavaScriptExecutor)_driver;
            jsExecutor4.ExecuteScript("arguments[0].click();", commLabel4);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetFeatureTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [Test]
        public void PetDeclarationTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel2 = _driver.FindElement(By.XPath($"//label[contains(.,'Cat')]"));
            IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)_driver;
            jsExecutor2.ExecuteScript("arguments[0].click();", commLabel2);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("BreedId")).SendKeys("TestBreed");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("PetName")).SendKeys("PetName");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel3 = _driver.FindElement(By.XPath($"//label[contains(.,'Female')]"));
            IJavaScriptExecutor jsExecutor3 = (IJavaScriptExecutor)_driver;
            jsExecutor3.ExecuteScript("arguments[0].click();", commLabel3);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2023");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel4 = _driver.FindElement(By.XPath($"//label[contains(.,'White')]"));
            IJavaScriptExecutor jsExecutor4 = (IJavaScriptExecutor)_driver;
            jsExecutor4.ExecuteScript("arguments[0].click();", commLabel4);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel5 = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor5 = (IJavaScriptExecutor)_driver;
            jsExecutor5.ExecuteScript("arguments[0].click();", commLabel5);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor6 = (IJavaScriptExecutor)_driver;

            _driver.FindElement(By.XPath("//button[contains(@class,'govuk-button')] | //button[@type='submit']")).Click();
            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetDeclarationTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [Test]
        public void PetAcknowledgementTest()
        {
            _driver.Navigate().GoToUrl("https://tst-take-your-pet-from-gb-to-ni.azure.defra.cloud/");
            _driver.FindElement(By.Id("EnteredPassword")).SendKeys("RpEpGk13QYA8TKHaKZeRFmu7WSdMOhVk");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("user_id")).SendKeys("30 10 87 53 19 12");
            _driver.FindElement(By.Id("password")).SendKeys("Test@12345");
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("continue")).Click();
            Thread.Sleep(5000);
            _driver.FindElement(By.XPath("//button[contains(text(),'Apply for a document')]")).Click();
            IWebElement commLabel = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript("arguments[0].click();", commLabel);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("Name")).SendKeys("Test Name");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.XPath("//a[contains(text(),'Enter the address manually')]")).Click();
            _driver.FindElement(By.Id("AddressLineOne")).SendKeys("Test line1");
            _driver.FindElement(By.Id("TownOrCity")).SendKeys("Test City");
            _driver.FindElement(By.Id("Postcode")).SendKeys("Se10 0BN");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Phone")).SendKeys("+447424047434");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel1 = _driver.FindElement(By.XPath($"//label[contains(.,'Yes')]"));
            IJavaScriptExecutor jsExecutor1 = (IJavaScriptExecutor)_driver;
            jsExecutor1.ExecuteScript("arguments[0].click();", commLabel1);
            _driver.FindElement(By.Id("MicrochipNumber")).SendKeys("989798686767887");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2024");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel2 = _driver.FindElement(By.XPath($"//label[contains(.,'Cat')]"));
            IJavaScriptExecutor jsExecutor2 = (IJavaScriptExecutor)_driver;
            jsExecutor2.ExecuteScript("arguments[0].click();", commLabel2);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("BreedId")).SendKeys("TestBreed");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("PetName")).SendKeys("PetName");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel3 = _driver.FindElement(By.XPath($"//label[contains(.,'Female')]"));
            IJavaScriptExecutor jsExecutor3 = (IJavaScriptExecutor)_driver;
            jsExecutor3.ExecuteScript("arguments[0].click();", commLabel3);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            _driver.FindElement(By.Id("Day")).SendKeys("01");
            _driver.FindElement(By.Id("Month")).SendKeys("02");
            _driver.FindElement(By.Id("Year")).SendKeys("2023");
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel4 = _driver.FindElement(By.XPath($"//label[contains(.,'White')]"));
            IJavaScriptExecutor jsExecutor4 = (IJavaScriptExecutor)_driver;
            jsExecutor4.ExecuteScript("arguments[0].click();", commLabel4);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            IWebElement commLabel5 = _driver.FindElement(By.XPath($"//label[contains(.,'No')]"));
            IJavaScriptExecutor jsExecutor5 = (IJavaScriptExecutor)_driver;
            jsExecutor5.ExecuteScript("arguments[0].click();", commLabel5);
            _driver.FindElement(By.XPath("//button[contains(text(),'Continue')]")).Click();
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollBy(0,4000)", "");
            IJavaScriptExecutor jsExecutor6 = (IJavaScriptExecutor)_driver;

            _driver.FindElement(By.XPath("//button[contains(@class,'govuk-button')] | //button[@type='submit']")).Click();
            _driver.FindElement(By.XPath("//div[@class='govuk-checkboxes__item']/label[@for='AgreedToAccuracy']")).Click(); 
            _driver.FindElement(By.XPath("//div[@class='govuk-checkboxes__item']/label[@for='AgreedToPrivacyPolicy']")).Click();
            _driver.FindElement(By.XPath("//div[@class='govuk-checkboxes__item']/label[@for='AgreedToDeclaration']")).Click();
            _driver.FindElement(By.XPath("//button[contains(@class,'govuk-button')] | //button[@type='submit']")).Click();

            Thread.Sleep(2000);

            AxeResult axeResult = new AxeBuilder(_driver).Analyze();
            string path = Path.Combine(@"C:\Users\payewale\source\repos\nipts-pts-automation-tests\nipts-pts-automation-tests\Reports\", "PetAcknowledgementTest.html");
            _driver.CreateAxeHtmlReport(axeResult, path);
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
