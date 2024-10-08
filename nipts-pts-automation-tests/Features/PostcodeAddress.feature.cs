﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace nipts_pts_automation_tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PostcodeAddress")]
    [NUnit.Framework.CategoryAttribute("Regression")]
    public partial class PostcodeAddressFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Regression"};
        
#line 1 "PostcodeAddress.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "PostcodeAddress", "Update and verify Postcode Address on Pets application Portal", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Enter postcode and select address on Pets")]
        [NUnit.Framework.CategoryAttribute("CrossBrowser")]
        [NUnit.Framework.TestCaseAttribute("test", "Dogfennau teithio gydol oes i anifeiliaid anwes", "manylion chi", "ch enw llawn?", "ch cod post", "ch cyfeiriad?", "ch rhif ff", "TestFullName", "SE1 7PB", null)]
        public void EnterPostcodeAndSelectAddressOnPets(string logininfo, string nextPage, string nextPage1, string nextPage2, string nextPage3, string nextPage4, string nextPage5, string fullname, string postcode, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "CrossBrowser"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("nextPage1", nextPage1);
            argumentsOfScenario.Add("nextPage2", nextPage2);
            argumentsOfScenario.Add("nextPage3", nextPage3);
            argumentsOfScenario.Add("nextPage4", nextPage4);
            argumentsOfScenario.Add("nextPage5", nextPage5);
            argumentsOfScenario.Add("fullname", fullname);
            argumentsOfScenario.Add("postcode", postcode);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Enter postcode and select address on Pets", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
 testRunner.Given("that I navigate to the Pets application portal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.And("click on Welsh language", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 12
 testRunner.When("click on Apply for a document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
 testRunner.When("select \'Nac ydyn\' on Personal Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 15
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 17
 testRunner.When(string.Format("enter your full name \'{0}\'", fullname), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 20
 testRunner.When(string.Format("enter your postcode \'{0}\'", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 21
 testRunner.Then("verify total address found on select address page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.When("select address", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage4), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 24
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 25
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage5), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error message for invalid postcode")]
        [NUnit.Framework.TestCaseAttribute("test", "Dogfennau teithio gydol oes i anifeiliaid anwes", "TestFullName", "", "Rhowch god post", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Dogfennau teithio gydol oes i anifeiliaid anwes", "TestFullName", "SE10 1EE", "Rhowch god post yng Nghymru", null)]
        [NUnit.Framework.TestCaseAttribute("test", "Dogfennau teithio gydol oes i anifeiliaid anwes", "TestFullName", "SE1 7PBABCDEFGHIJKLMNOP", "Rhowch god post llawn yn y fformat cywir", null)]
        public void VerifyErrorMessageForInvalidPostcode(string logininfo, string nextPage, string fullname, string postcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("fullname", fullname);
            argumentsOfScenario.Add("postcode", postcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error message for invalid postcode", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 32
 testRunner.Given("that I navigate to the Pets application portal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 33
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 34
 testRunner.And("click on Welsh language", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.When("click on Apply for a document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 37
 testRunner.And("select \'Nac ydyn\' on Personal Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.When("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 39
 testRunner.When(string.Format("enter your full name \'{0}\'", fullname), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 41
 testRunner.When(string.Format("enter your postcode \'{0}\'", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 42
 testRunner.Then(string.Format("verify error message \'{0}\' on Pets", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Change postcode on what is your address page")]
        [NUnit.Framework.TestCaseAttribute("test", "Dogfennau teithio gydol oes i anifeiliaid anwes", "TestFullName", "SE10 0BP", "ch cyfeiriad", "ch cod post", null)]
        public void ChangePostcodeOnWhatIsYourAddressPage(string logininfo, string nextPage, string fullname, string postcode, string nextPage1, string nextPage2, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("fullname", fullname);
            argumentsOfScenario.Add("postcode", postcode);
            argumentsOfScenario.Add("nextPage1", nextPage1);
            argumentsOfScenario.Add("nextPage2", nextPage2);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change postcode on what is your address page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 50
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 51
 testRunner.Given("that I navigate to the Pets application portal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 52
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 53
 testRunner.And("click on Welsh language", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 54
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 55
 testRunner.When("click on Apply for a document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 56
 testRunner.And("select \'Nac ydyn\' on Personal Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
 testRunner.When("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 58
 testRunner.When(string.Format("enter your full name \'{0}\'", fullname), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 59
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 60
 testRunner.When(string.Format("enter your postcode \'{0}\'", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 61
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 62
 testRunner.When("click on change postcode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify error message on select address page on Pets")]
        [NUnit.Framework.TestCaseAttribute("test", "Dogfennau teithio gydol oes i anifeiliaid anwes", "manylion chi", "ch enw llawn?", "ch cod post", "TestFullName", "SE1 7PB", "Dewiswch eich cyfeiriad o blith y rhestr", null)]
        public void VerifyErrorMessageOnSelectAddressPageOnPets(string logininfo, string nextPage, string nextPage1, string nextPage2, string nextPage3, string fullname, string postcode, string errorMessage, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("nextPage1", nextPage1);
            argumentsOfScenario.Add("nextPage2", nextPage2);
            argumentsOfScenario.Add("nextPage3", nextPage3);
            argumentsOfScenario.Add("fullname", fullname);
            argumentsOfScenario.Add("postcode", postcode);
            argumentsOfScenario.Add("errorMessage", errorMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify error message on select address page on Pets", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 69
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 70
 testRunner.Given("that I navigate to the Pets application portal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 71
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 72
 testRunner.And("click on Welsh language", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 73
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 74
 testRunner.When("click on Apply for a document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 75
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 76
 testRunner.When("select \'Nac ydyn\' on Personal Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 77
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 78
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 79
 testRunner.When(string.Format("enter your full name \'{0}\'", fullname), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 80
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 81
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 82
 testRunner.When(string.Format("enter your postcode \'{0}\'", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 83
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
 testRunner.Then(string.Format("verify error message \'{0}\' on Pets", errorMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify cannot find address link on select address page on Pets")]
        [NUnit.Framework.TestCaseAttribute("test", "Dogfennau teithio gydol oes i anifeiliaid anwes", "manylion chi", "ch enw llawn?", "ch cod post", "ch cyfeiriad?", "TestFullName", "SE1 7PB", null)]
        public void VerifyCannotFindAddressLinkOnSelectAddressPageOnPets(string logininfo, string nextPage, string nextPage1, string nextPage2, string nextPage3, string nextPage4, string fullname, string postcode, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("logininfo", logininfo);
            argumentsOfScenario.Add("nextPage", nextPage);
            argumentsOfScenario.Add("nextPage1", nextPage1);
            argumentsOfScenario.Add("nextPage2", nextPage2);
            argumentsOfScenario.Add("nextPage3", nextPage3);
            argumentsOfScenario.Add("nextPage4", nextPage4);
            argumentsOfScenario.Add("fullname", fullname);
            argumentsOfScenario.Add("postcode", postcode);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify cannot find address link on select address page on Pets", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 90
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 91
 testRunner.Given("that I navigate to the Pets application portal", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 92
 testRunner.When(string.Format("sign in with valid credentials with logininfo \'{0}\'", logininfo), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 93
 testRunner.And("click on Welsh language", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 94
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 95
 testRunner.When("click on Apply for a document", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 96
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 97
 testRunner.When("select \'Nac ydyn\' on Personal Details page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 98
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 99
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 100
 testRunner.When(string.Format("enter your full name \'{0}\'", fullname), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 101
 testRunner.And("click on continue", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 102
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage3), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 103
 testRunner.When(string.Format("enter your postcode \'{0}\'", postcode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 104
 testRunner.And("click on I cannot find the address in the list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 105
 testRunner.Then(string.Format("verify next page \'{0}\' is loaded", nextPage4), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
