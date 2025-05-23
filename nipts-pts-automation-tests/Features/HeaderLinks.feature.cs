﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:2.0.0.0
//      Reqnroll Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
using Reqnroll;
namespace nipts_pts_automation_tests.Features
{
    
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "2.0.0.0")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("HeaderLinks")]
    [NUnit.Framework.FixtureLifeCycleAttribute(NUnit.Framework.LifeCycle.InstancePerTestCase)]
    [NUnit.Framework.CategoryAttribute("Regression")]
    public partial class HeaderLinksFeature
    {
        
        private global::Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Regression"};
        
        private static global::Reqnroll.FeatureInfo featureInfo = new global::Reqnroll.FeatureInfo(new global::System.Globalization.CultureInfo("en-US"), "Features", "HeaderLinks", "Pets header page", global::Reqnroll.ProgrammingLanguage.CSharp, featureTags);
        
#line 1 "HeaderLinks.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public static async global::System.Threading.Tasks.Task FeatureSetupAsync()
        {
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public static async global::System.Threading.Tasks.Task FeatureTearDownAsync()
        {
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async global::System.Threading.Tasks.Task TestInitializeAsync()
        {
            testRunner = global::Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(featureHint: featureInfo);
            try
            {
                if (((testRunner.FeatureContext != null) 
                            && (testRunner.FeatureContext.FeatureInfo.Equals(featureInfo) == false)))
                {
                    await testRunner.OnFeatureEndAsync();
                }
            }
            finally
            {
                if (((testRunner.FeatureContext != null) 
                            && testRunner.FeatureContext.BeforeFeatureHookFailed))
                {
                    throw new global::Reqnroll.ReqnrollException("Scenario skipped because of previous before feature hook error");
                }
                if ((testRunner.FeatureContext == null))
                {
                    await testRunner.OnFeatureStartAsync(featureInfo);
                }
            }
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async global::System.Threading.Tasks.Task TestTearDownAsync()
        {
            if ((testRunner == null))
            {
                return;
            }
            try
            {
                await testRunner.OnScenarioEndAsync();
            }
            finally
            {
                global::Reqnroll.TestRunnerManager.ReleaseTestRunner(testRunner);
                testRunner = null;
            }
        }
        
        public void ScenarioInitialize(global::Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async global::System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async global::System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Check header page links")]
        [NUnit.Framework.TestCaseAttribute("test", "Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon", "Mae hwn yn wasanaeth newydd - bydd", null)]
        public async global::System.Threading.Tasks.Task CheckHeaderPageLinks(string logininfo, string title, string bannerText, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("title", title);
            argumentsOfScenario.Add("bannerText", bannerText);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Check header page links", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 8
 await testRunner.GivenAsync("that I navigate to the Pets application portal", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 9
 await testRunner.WhenAsync(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 10
 await testRunner.WhenAsync("click on Welsh language", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 11
 await testRunner.ThenAsync(string.Format("verify header title \'{0}\'", title), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 12
 await testRunner.ThenAsync(string.Format("verify header banner \'{0}\'", bannerText), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 13
 await testRunner.WhenAsync("click on the feedback link", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 14
 await testRunner.AndAsync("switch to next opened tab", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 15
 await testRunner.ThenAsync("verify feedback page is loaded", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 16
 await testRunner.AndAsync("verify feedback page text \'Your feedback will help us improve the service.\' is co" +
                        "rrect", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 17
 await testRunner.AndAsync("verify link \'Accessibility statement (opens in a new tab)\' on feedback page text", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 18
 await testRunner.WhenAsync("switch to previous tab", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 19
 await testRunner.AndAsync("Click on GOV.UK link in the header of the page", ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 20
 await testRunner.ThenAsync("verify generic GOV page is loaded", ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify Cookies Banner in WELSH")]
        [NUnit.Framework.TestCaseAttribute("test", "Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon", "Cwcis ar fynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon", null)]
        public async global::System.Threading.Tasks.Task VerifyCookiesBannerInWELSH(string logininfo, string title, string cookiesText, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("title", title);
            argumentsOfScenario.Add("cookiesText", cookiesText);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Verify Cookies Banner in WELSH", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 28
 await testRunner.GivenAsync("delete browser cookies", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 29
 await testRunner.GivenAsync("that I navigate to the Pets application portal", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 30
 await testRunner.WhenAsync(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 31
 await testRunner.WhenAsync("click on Welsh language", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 32
 await testRunner.ThenAsync(string.Format("verify header title \'{0}\'", title), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 33
 await testRunner.ThenAsync(string.Format("verify cookies banner \'{0}\' in WELSH", cookiesText), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify text for accepted cookies Banner in WELSH")]
        [NUnit.Framework.TestCaseAttribute("test", "Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon", "Cwcis ar fynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon", "Rydych chi wedi derbyn cwcis ychwanegol", "Derbyn cwcis ychwanegol", null)]
        public async global::System.Threading.Tasks.Task VerifyTextForAcceptedCookiesBannerInWELSH(string logininfo, string title, string cookiesText, string selectedCookiesText, string cookiesPrefBtn, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("title", title);
            argumentsOfScenario.Add("cookiesText", cookiesText);
            argumentsOfScenario.Add("SelectedCookiesText", selectedCookiesText);
            argumentsOfScenario.Add("CookiesPrefBtn", cookiesPrefBtn);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Verify text for accepted cookies Banner in WELSH", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 39
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 40
 await testRunner.GivenAsync("delete browser cookies", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 41
 await testRunner.GivenAsync("that I navigate to the Pets application portal", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 42
 await testRunner.WhenAsync(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 43
 await testRunner.WhenAsync("click on Welsh language", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 44
 await testRunner.ThenAsync(string.Format("verify header title \'{0}\'", title), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 45
 await testRunner.ThenAsync(string.Format("verify cookies banner \'{0}\' in WELSH", cookiesText), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 46
 await testRunner.AndAsync(string.Format("click on cookies preference button \'{0}\' button in WELSH on cookies banner", cookiesPrefBtn), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 47
 await testRunner.ThenAsync(string.Format("verify text on the cookies preference banner \'{0}\'", selectedCookiesText), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify text for rejected cookies Banner in WELSH")]
        [NUnit.Framework.TestCaseAttribute("test", "Mynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon", "Cwcis ar fynd ag anifail anwes o Brydain Fawr i Ogledd Iwerddon", "Rydych chi wedi gwrthod cwcis ychwanegol", "Gwrthod cwcis ychwanegol", null)]
        public async global::System.Threading.Tasks.Task VerifyTextForRejectedCookiesBannerInWELSH(string logininfo, string title, string cookiesText, string selectedCookiesText, string cookiesPrefBtn, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            global::System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new global::System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("title", title);
            argumentsOfScenario.Add("cookiesText", cookiesText);
            argumentsOfScenario.Add("SelectedCookiesText", selectedCookiesText);
            argumentsOfScenario.Add("CookiesPrefBtn", cookiesPrefBtn);
            global::Reqnroll.ScenarioInfo scenarioInfo = new global::Reqnroll.ScenarioInfo("Verify text for rejected cookies Banner in WELSH", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 53
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((global::Reqnroll.TagHelper.ContainsIgnoreTag(scenarioInfo.CombinedTags) || global::Reqnroll.TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 54
 await testRunner.GivenAsync("delete browser cookies", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 55
 await testRunner.GivenAsync("that I navigate to the Pets application portal", ((string)(null)), ((global::Reqnroll.Table)(null)), "Given ");
#line hidden
#line 56
 await testRunner.WhenAsync(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 57
 await testRunner.WhenAsync("click on Welsh language", ((string)(null)), ((global::Reqnroll.Table)(null)), "When ");
#line hidden
#line 58
 await testRunner.ThenAsync(string.Format("verify header title \'{0}\'", title), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 59
 await testRunner.ThenAsync(string.Format("verify cookies banner \'{0}\' in WELSH", cookiesText), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
#line 60
 await testRunner.AndAsync(string.Format("click on cookies preference button \'{0}\' button in WELSH on cookies banner", cookiesPrefBtn), ((string)(null)), ((global::Reqnroll.Table)(null)), "And ");
#line hidden
#line 61
 await testRunner.ThenAsync(string.Format("verify text on the cookies preference banner \'{0}\'", selectedCookiesText), ((string)(null)), ((global::Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
