namespace nipts_pts_automation_tests.Pages.CP.Interfaces
{
    public interface IRouteCheckingPage
    {
        bool IsPageLoaded();
        void SelectTransportationOption(string option);
        void SelectFerryRouteOption(string routeOption);
        string SelectDropDownDepartureTime();
        void SelectSaveAndContinue();
        bool IsError(string errorMessage);
        void SelectFlightNumber(string routeFlight);
        void SelectScheduledDepartureDate(string departureDay, string departureMonth, string departureYear);
        void SelectDropDownDepartureTimeMinuteOnly();
        void SelectDropDownDepartureTimeWithSPS();
        string SelectfutureDropDownDepartureTime();
        void EnterDateMonthYear(DateTime dateTime);
        string SelectDropDownDepartureTimeJustOneMinuteLaterThanCurrent();
        string SelectDropDownDepartureTimeJustOneMinuteBeforeThanCurrent();
        public bool VerifyFilterFlightMsg(string FlightMsgPTD, string FlightMsgAppno, string FlightMsgMichrochipNo);
        public bool VerifyFilterFlightHeaderMsg(string FlightHeaderMsg);
        bool VerifyTheHeaderText(string headerText);
    }
}
