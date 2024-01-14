using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using ModelReplacement;
using BepInEx.Configuration;
using VRC_Game_Company.Replacements;

namespace VRC_Game_Company
{
    //  ____   _______________________     ________                        _________                                           
    //  \   \ /   /\______   \_   ___ \   /  _____/_____    _____   ____   \_   ___ \  ____   _____ ___________    ____ ___.__.
    //   \   Y   /  |       _/    \  \/  /   \  ___\__  \  /     \_/ __ \  /    \  \/ /  _ \ /     \\____ \__  \  /    <   |  |
    //    \     /   |    |   \     \____ \    \_\  \/ __ \|  Y Y  \  ___/  \     \___(  <_> )  Y Y  \  |_> > __ \|   |  \___  |
    //     \___/    |____|_  /\______  /  \______  (____  /__|_|  /\___  >  \______  /\____/|__|_|  /   __(____  /___|  / ____|
    //                     \/        \/          \/     \/      \/     \/          \/             \/|__|       \/     \/\/     
    [BepInPlugin("null-base.VRC-Game-Company", "VRC-Game-Company", "0.0.1")]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("x753.More_Suits", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigFile config;

        // Universal config options
        public static ConfigEntry<bool> enableAnomeaSuit { get; private set; }
        public static ConfigEntry<bool> enableNagiSuit { get; private set; }
        public static ConfigEntry<bool> enableZomeSuit { get; private set; }


        private static void InitConfig()
        {
            enableAnomeaSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Anomea for", true, "Enable Anomea Suit");
            enableNagiSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Nagi for", true, "Enable Nagi Suit");
            enableZomeSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Zome for", true, "Enable Zome Suit");

        }
        private void Awake()
        {
            config = base.Config;
            InitConfig();
            Assets.PopulateAssets();

            // Plugin startup logic
            if (enableAnomeaSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Anomea", typeof(AnomeaReplacement));

            }

            if (enableNagiSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Nagi", typeof(NagiReplacement));

            }

            if (enableZomeSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Zome", typeof(ZomeReplacement));

            }


            Harmony harmony = new Harmony("null-base.VRC-Game-Company");
            harmony.PatchAll();
            Logger.LogInfo("\n" +
                           "____   _______________________     ________                        _________                                           \n" +
                           "\\   \\ /   /\\______   \\_   ___ \\   /  _____/_____    _____   ____   \\_   ___ \\  ____   _____ ___________    ____ ___.__.\n" +
                           " \\   Y   /  |       _/    \\  \\/  /   \\  ___\\__  \\  /     \\_/ __ \\  /    \\  \\/ /  _ \\ /     \\\\____ \\__  \\  /    <   |  |\n" +
                           "  \\     /   |    |   \\     \\____ \\    \\_\\  \\/ __ \\|  Y Y  \\  ___/  \\     \\___(  <_> )  Y Y  \\  |_> > __ \\|   |  \\___  |\n" +
                           "   \\___/    |____|_  /\\______  /  \\______  (____  /__|_|  /\\___  >  \\______  /\\____/|__|_|  /   __(____  /___|  / ____|\n" +
                           "                   \\/        \\/          \\/     \\/      \\/     \\/          \\/             \\/|__|       \\/     \\/\\/     ");
            Logger.LogInfo($"Plugin {"null-base.VRC-Game-Company"} is loaded!");
        }
    }
    public static class Assets
    {
        // Replace mbundle with the Asset Bundle Name from your unity project
        public static string MainAssetBundleName = "VRCGCbundle";
        public static AssetBundle MainAssetBundle = null;

        private static string GetAssemblyName() => Assembly.GetExecutingAssembly().GetName().Name;
        public static void PopulateAssets()
        {
            if (MainAssetBundle == null)
            {
                //Console.WriteLine(GetAssemblyName() + "." + mainAssetBundleName);
                using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + MainAssetBundleName))
                {
                    MainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                }

            }
        }
    }

}
