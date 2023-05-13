using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessStats
{
    public class StatsCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "stats";

        public string Help => "Changes if you should have infinite stats or not.";

        public string Syntax => "<on/off>";

        public List<string> Aliases => new() { "jstats" };

        public List<string> Permissions => new() { "j.stats" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;
            if (command.Length < 1) { UnturnedChat.Say(caller, EndlessStats.Instance.Translate("InvalidSyntax")); return; }
            string lower = command[0].ToLower();
            if (lower != "on" && lower != "off") { UnturnedChat.Say(caller, EndlessStats.Instance.Translate("InvalidSyntax")); return; }

            if (lower == "on")
            {
                EndlessStats.Instance.Systems[player.CSteamID].Activate();
                UnturnedChat.Say(caller, EndlessStats.Instance.Translate("StatsOn"));
            }
            else
            {
                EndlessStats.Instance.Systems[player.CSteamID].Deactivate();
                UnturnedChat.Say(caller, EndlessStats.Instance.Translate("StatsOff"));
            }
            return;
        }
    }
}
