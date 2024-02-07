using System;
using System.Reflection;
using MonoMod.RuntimeDetour;
using BepInEx;

namespace JuicePlugin
{
    [BepInPlugin("grug.juice.PlayerMods","Player Mods","0.0.0.1")]
    public class JuicePlugin
    {
        public void Awake()
        {
            Hook startOfRoundHook = new(
            typeof(PlayerGlide).GetMethod(nameof(PlayerGlide.Update), (BindingFlags)int.MaxValue),
            (Action<PlayerGlide> original, PlayerGlide self) =>
            {
                self.energyCost = 0f;
                original(self);
            });
        }
    }
}
