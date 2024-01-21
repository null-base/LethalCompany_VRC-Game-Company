using BepInEx;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using ModelReplacement;
using BepInEx.Configuration;
using VRC_Game_Company.Replacements;

namespace VRC_Game_Company
{
    public static class PluginInformation
    {
        public const string PLUGIN_NAME = "VRC-Game-Company";
        public const string PLUGIN_VERSION = "0.0.3";
        public const string PLUGIN_GUID = "null-base.VRC-Game-Company";
    }
    
    //  ____   _______________________     ________                        _________                                           
    //  \   \ /   /\______   \_   ___ \   /  _____/_____    _____   ____   \_   ___ \  ____   _____ ___________    ____ ___.__.
    //   \   Y   /  |       _/    \  \/  /   \  ___\__  \  /     \_/ __ \  /    \  \/ /  _ \ /     \\____ \__  \  /    <   |  |
    //    \     /   |    |   \     \____ \    \_\  \/ __ \|  Y Y  \  ___/  \     \___(  <_> )  Y Y  \  |_> > __ \|   |  \___  |
    //     \___/    |____|_  /\______  /  \______  (____  /__|_|  /\___  >  \______  /\____/|__|_|  /   __(____  /___|  / ____|
    //                     \/        \/          \/     \/      \/     \/          \/             \/|__|       \/     \/\/     
    [BepInPlugin(PluginInformation.PLUGIN_GUID, PluginInformation.PLUGIN_NAME, PluginInformation.PLUGIN_VERSION)]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("x753.More_Suits", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigFile config;

        // Universal config options
        public static ConfigEntry<bool> enableAnomeaSuit { get; private set; }
        public static ConfigEntry<bool> enableAnomeaPinkSuit { get; private set; }
        public static ConfigEntry<bool> enableAnomeaPurpleSuit { get; private set; }
        public static ConfigEntry<bool> enableAnomeaBlackSuit { get; private set; }
        public static ConfigEntry<bool> enableBlazeSuit { get; private set; }
        public static ConfigEntry<bool> enableNagiSuit { get; private set; }
        public static ConfigEntry<bool> enableSenbyoSuit { get; private set; }
        public static ConfigEntry<bool> enableZomeSuit { get; private set; }
        public static ConfigEntry<bool> enableVRCGameCompanyLogo { get; private set; }


        private static void InitConfig()
        {
            enableAnomeaSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Anomea for", true, "Enable Anomea Suit");
            enableAnomeaPinkSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Anomea (Pink) for", true, "Enable Anomea (Pink) Suit");
            enableAnomeaPurpleSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Anomea (Purple) for", true, "Enable Anomea (Purple) Suit");
            enableAnomeaBlackSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Anomea (Black) for", true, "Enable Anomea (Black) Suit");
            enableBlazeSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Blaze for", true, "Enable Blaze Suit");
            enableNagiSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Nagi for", true, "Enable Nagi Suit");
            enableSenbyoSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Senbyo for", true, "Enable Senbyo Suit");
            enableZomeSuit = config.Bind<bool>("Suits to Add Settings", "Suits to enable Zome for", true, "Enable Zome Suit");
            enableVRCGameCompanyLogo = config.Bind<bool>("Logo Settings", "Enable VRC Game Company Logo", true, "Enable VRC Game Company Logo");

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
            
            if (enableAnomeaPinkSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Anomea (Pink)", typeof(AnomeaPinkReplacement));

            }
            
            if (enableAnomeaPurpleSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Anomea (Purple)", typeof(AnomeaPurpleReplacement));

            }
            
            if (enableAnomeaBlackSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Anomea (Black)", typeof(AnomeaBlackReplacement));

            }
            
            if (enableBlazeSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Blaze", typeof(BlazeReplacement));

            }

            if (enableNagiSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Nagi", typeof(NagiReplacement));

            }
            
            if (enableSenbyoSuit.Value)
            {
                ModelReplacementAPI.RegisterSuitModelReplacement("Senbyo", typeof(SenbyoReplacement));

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
        public static string MainAssetBundleName = "vrc-game-company";
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