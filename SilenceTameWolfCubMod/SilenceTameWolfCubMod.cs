using BepInEx;
using HarmonyLib;

namespace ValheimTameMods
{
    [BepInPlugin("afilbert.ValheimSilenceTameWolfCubMod", "Valheim - Silence Tame Wolf Cub Howls", "0.0.1")]
    [BepInProcess("valheim.exe")]
    public class SilenceTameWolfCubMod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("afilbert.ValheimSilenceTameWolfCubMod");

        void Awake()
        {
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(ZSFX), nameof(ZSFX.Play))]
        class SilenceTheirYoungPatch
        {
            static bool Prefix(ref ZSFX __instance)
            {
                bool allowAttachment = true;
                if (__instance.name.Contains("sfx_wolf_haul"))
                {
                    System.Collections.Generic.List<Character> characters = new System.Collections.Generic.List<Character>();
                    Character.GetCharactersInRange(__instance.transform.position, 30f, characters);
                    allowAttachment = !characters.Exists(c => c.IsTamed() && (c.name == "Wolf_cub(Clone)" || c.name == "Wolf_cub"));
                }
                return allowAttachment;
            }
        }
    }
}