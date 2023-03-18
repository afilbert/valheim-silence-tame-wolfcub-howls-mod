using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace ValheimTameMods
{
    [BepInPlugin("afilbert.ValheimSilenceTameWolfCubMod", "Valheim - Silence Tame Wolf Cub Howls", "0.0.4")]
    [BepInProcess("valheim.exe")]
    public class SilenceTameWolfCubMod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("afilbert.ValheimSilenceTameWolfCubMod");

        public static ConfigEntry<bool> EnableToggle;
        public static ConfigEntry<bool> SilenceAdults;
        public static ConfigEntry<float> SilenceRange;

        void Awake()
        {
            harmony.PatchAll();
            EnableToggle = Config.Bind<bool>("Mod", "EnableToggleFlag", true, "Enable this mod");
            SilenceAdults = Config.Bind<bool>("Mod", "SilenceAdultsFlag", false, "Also silence adult wolves (tamed or otherwise)");
            SilenceRange = Config.Bind<float>("Range", "SilenceRangeValue", 30f, "Radius in meters within which wolves are silenced");
        }

        [HarmonyPatch(typeof(ZSFX), nameof(ZSFX.Play))]
        class SilenceTheirYoungPatch
        {
            static bool Prefix(ref ZSFX __instance)
            {
                bool allowAttachment = true;
                if (__instance.name.Contains("sfx_wolf_haul") && EnableToggle.Value)
                {
                    System.Collections.Generic.List<Character> characters = new System.Collections.Generic.List<Character>();
                    Character.GetCharactersInRange(__instance.transform.position, SilenceRange.Value, characters);
                    allowAttachment = !characters.Exists(c => (c.IsTamed() || SilenceAdults.Value) && (c.name == "Wolf_cub(Clone)" || c.name == "Wolf_cub" || (SilenceAdults.Value && (c.name == "Wolf(Clone)" || c.name == "Wolf"))));
                }
                return allowAttachment;
            }
        }
    }
}