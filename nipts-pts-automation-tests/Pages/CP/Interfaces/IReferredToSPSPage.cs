﻿namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IReferredToSPSPage
    {
        void ClickOnPTDNumberOfTheApplication(string ptdNumber);
        public bool VerifyPetDocumentDetailsOnReferredToSPSPage(string ptdNumberNew, string petType, string michrochipNo);
        public bool VerifySPSOutcome(string outcome);
        public bool VerifyDepartureDetailsOnReferredToSPSPage();
        void ClickOnPage(string pageNumber);
        bool VerifyReferredToSPSRecordCount(int count);
        void ClickOnNextPage(string nextPage);
        void GetPTDReferenceAndAddInCollection();
        void ArrangePTDRefNumberInAscendingOrder();
        bool VerifyAscendingOderOfPTDReference();
        bool VerifyPetSpeciesAndColourOnReferredToSPSPage(string Species, string Colour);
    }
}
