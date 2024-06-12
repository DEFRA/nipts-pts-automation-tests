using Defra.UI.Framework.Configuration;

namespace pets_com_automation_tests.Configuration
{
    public class UiFrameworkConfiguration : IFrameworkConfiguration
    {

        private string _grid;
        public string Target { get; set; }
        public bool IsDebug { get; set; }


        public string SeleniumGrid
        {
            get => _grid ?? string.Empty;
            set => _grid = value;
        }
    }

}
