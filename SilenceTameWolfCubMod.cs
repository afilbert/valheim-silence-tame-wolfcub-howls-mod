using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;
using System.ComponentModel;

namespace ValheimTameMods
{
    [BepInPlugin("afilbert.ValheimSilenceTameWolfCubMod", "Valheim - Silence Tame Wolf Cub Howls", "0.1.0")]
    [BepInProcess("valheim.exe")]
    public class SilenceTameWolfCubMod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("afilbert.ValheimSilenceTameWolfCubMod");
        public static ManualLogSource logger;

        public static ConfigEntry<bool> EnableToggle;
        public static ConfigEntry<bool> SilenceAdults;
        public static ConfigEntry<bool> SilenceChickens;
        public static ConfigEntry<float> SilenceRange;

        void Awake()
        {
            harmony.PatchAll();
            logger = Logger;
            EnableToggle = Config.Bind<bool>("Mod", "EnableToggleFlag", true, "Enable this mod");
            SilenceAdults = Config.Bind<bool>("Mod", "SilenceAdultsFlag", false, "Also silence adult wolves (tamed or otherwise)");
            SilenceChickens = Config.Bind<bool>("Mod", "SilenceChickens", false, "Also silence chicken crowing");
            SilenceRange = Config.Bind<float>("Range", "SilenceRangeValue", 30f, "Radius in meters within which wolves are silenced");
        }

        [HarmonyPatch(typeof(ZSFX), nameof(ZSFX.Play))]
        class SilenceTheirYoungPatch
        {
            static bool Prefix(ref ZSFX __instance)
            {
                if (!EnableToggle.Value)
                {
                    return true;
                }

                bool allowAttachment = true;

                if (__instance.name.Contains("sfx_wolf_haul"))
                {
                    System.Collections.Generic.List<Character> characters = new System.Collections.Generic.List<Character>();
                    Character.GetCharactersInRange(__instance.transform.position, SilenceRange.Value, characters);
                    allowAttachment = !characters.Exists(c => (c.IsTamed() || SilenceAdults.Value) && (c.name == "Wolf_cub(Clone)" || c.name == "Wolf_cub" || (SilenceAdults.Value && (c.name == "Wolf(Clone)" || c.name == "Wolf"))));
                }

                if (SilenceChickens.Value && __instance.name.Contains("sfx_love"))
                {
                    allowAttachment = false;
                }

                return allowAttachment;
            }
        }
    }
}