using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessStats
{
    public class EndlessStatsConfiguration : IRocketPluginConfiguration
    {
        public bool DefaultOn { get; set; }
        public bool ShouldHeal { get; set; }
        public bool ShouldThrist { get; set; }
        public bool ShouldHunger { get; set; }
        public bool ShouldInfection { get; set; }
        public bool ShouldStamina { get; set; }

        public void LoadDefaults()
        {
            DefaultOn = true;
            ShouldHeal = true;
            ShouldThrist = true;
            ShouldHunger = true;
            ShouldInfection = true;
            ShouldStamina = true;
        }
    }
}
