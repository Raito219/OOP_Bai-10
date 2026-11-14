using System;

namespace SmartHome
{
    public sealed class HomeConfiguration
    {
        private static readonly Lazy<HomeConfiguration> lazy = new Lazy<HomeConfiguration>(() => new HomeConfiguration());
        
        public static HomeConfiguration Instance
        {
            get { return lazy.Value; }
        }

        public string HomeName { get; set; }
        public int NightLightLevel { get; set; }

        private HomeConfiguration()
        {
            HomeName = "Nhà của Phúc";
            NightLightLevel = 30;
        }
    }
}

