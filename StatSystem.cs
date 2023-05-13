using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessStats
{
    public class StatSystem
    {
        public UnturnedPlayer NativePlayer { get; set; }

        public StatSystem(UnturnedPlayer player)
        {
            NativePlayer = player;
        }

        public void Activate()
        {
            NativePlayer.Player.life.onLifeUpdated += HandleUpdateLife;
        }

        public void Deactivate()
        {
            NativePlayer.Player.life.onLifeUpdated -= HandleUpdateLife;
        }

        private void HandleUpdateLife(bool isDead)
        {
            Task.Run(() =>
            {
                if (!isDead)
                {
                    if (EndlessStats.Instance.Configuration.Instance.ShouldHeal)
                        NativePlayer.Heal(100);
                    if (EndlessStats.Instance.Configuration.Instance.ShouldThrist)
                        NativePlayer.Thirst = 0;
                    if (EndlessStats.Instance.Configuration.Instance.ShouldHunger)
                        NativePlayer.Hunger = 0;
                    if (EndlessStats.Instance.Configuration.Instance.ShouldInfection)
                        NativePlayer.Infection = 0;
                    if (EndlessStats.Instance.Configuration.Instance.ShouldStamina)
                        NativePlayer.Player.life.serverModifyStamina(100);
                }
            });
        }
    }
}
