using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessStats
{
    public class EndlessStats : RocketPlugin<EndlessStatsConfiguration>
    {
        public static EndlessStats Instance { get; set; }
        public Dictionary<CSteamID, StatSystem> Systems { get; set; }

        protected override void Load()
        {
            Logger.Log("EndlessStats by JStudio is now loaded.");
            Instance = this;
            Systems = new();
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
        }

        private void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            Systems.Remove(player.CSteamID);
        }

        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            Systems.Add(player.CSteamID, new StatSystem(player));
            if (player.HasPermission("j.stats") && Configuration.Instance.DefaultOn)
                Systems[player.CSteamID].Activate();
        }

        protected override void Unload()
        {
            Logger.Log("EndlessStats by JStudio is now unloaded.");

            Systems = null;
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
        }

        public override TranslationList DefaultTranslations => new()
        {
            { "InvalidSyntax", "Specified syntax was invalid."},
            { "StatsOn", "EndlessStats has been turned on."},
            { "StatsOff", "EndlessStats has been turned off"}
        };
    }
}
