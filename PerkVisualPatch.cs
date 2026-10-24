using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;

namespace AutoDualPerks
{
    [HarmonyPatch(typeof(PerkVM), "get__hasAlternativeAndSelected")]
    public static class PerkVMHasAlternativeAndSelectedPatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = false;
            return false;
        }
    }

    [HarmonyPatch(typeof(HeroDeveloper), "AddPerk")]
    public static class HeroDeveloperAddPerkPatch
    {
        [ThreadStatic]
        private static bool _isGrantingAlternative;

        [HarmonyPostfix]
        public static void Postfix(HeroDeveloper __instance, PerkObject perk)
        {
            if (_isGrantingAlternative)
            {
                return;
            }

            if (__instance?.Hero == Hero.MainHero && perk?.AlternativePerk != null && !__instance.Hero.GetPerkValue(perk.AlternativePerk))
            {
                try
                {
                    _isGrantingAlternative = true;
                    __instance.Hero.HeroDeveloper.AddPerk(perk.AlternativePerk);
                }
                finally
                {
                    _isGrantingAlternative = false;
                }
            }
        }
    }
}
