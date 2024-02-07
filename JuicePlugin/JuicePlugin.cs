using System;
using System.Reflection;

namespace JuicePlugin
{
    public class JuicePlugin
    {
        public void Awake()
        {
            Hook startOfRoundHook = new(
            typeof(PlayerGlide).GetMethod(nameof(PlayerGlide.Update), (BindingFlags)int.MaxValue),
            (Action<HUDManager> original, HUDManager self) =>
            {
                StartCoroutine(WaitUntilPostProcessApi());
                original(self);
            });
        }
    }
}
