using System;
using UnityEngine;
using HarmonyLib;
using UnityEngine.UI;

namespace VRC_Game_Company
{
    [HarmonyPatch(typeof(MenuManager), "Awake")]
    public static class MenuManagerLogoOverridePatch
    {
        public static Texture2D mainLogo;
        public static void Postfix(MenuManager __instance)
        {
            try
            {
                GameObject parent = __instance.transform.parent.gameObject;
                GameObject logo = parent.transform.Find("MenuContainer").Find("MainButtons").Find("HeaderImage").gameObject;
                Image image = logo.GetComponent<Image>();

                mainLogo = Assets.MainAssetBundle.LoadAsset<Texture2D>("VRCGameCompanyLogo");

                if (Plugin.enableVRCGameCompanyLogo.Value)
                {
                    image.sprite = Sprite.Create(mainLogo, new Rect(0, 0, mainLogo.width, mainLogo.height), new Vector2(0.5f, 0.5f));
                }

            }
            catch (Exception e)
            {
                Debug.Log("VRC Game Company: Failed to replace logo: " + e);
            }
        }
    }

}