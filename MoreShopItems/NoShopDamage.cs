using BepInEx.Logging;
using MoreShopItems;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoreShopItems
{
    [HarmonyPatch]
    public class NoShopDamage
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(PlayerHealth), nameof(PlayerHealth.Hurt))]
        public static bool HurtPrefix()
        {
            if (Plugin.Instance.boolConfigEntries["No Shop Damage"].Value)
            {
                if (RunManager.instance.levelCurrent == RunManager.instance.levelShop)
                {
                    if (ChatManager.instance.betrayalActive)
                    {
                        return true;
                    }

                    return false;
                }
            }
            
            return true;
        }
    }
}