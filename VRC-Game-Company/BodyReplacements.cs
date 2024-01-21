using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ModelReplacement;
using GameNetcodeStuff;
using Unity.Netcode;

namespace VRC_Game_Company.Replacements
{
    public class AnomeaReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "Anomea";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
    
    public class AnomeaPinkReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "Anomea (Pink)";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }

    public class AnomeaPurpleReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "Anomea (Purple)";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
    
    public class AnomeaBlackReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "Anomea (Black)";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
    public class BlazeReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "Blaze";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
    public class NagiReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "Nagi";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
    
    public class SenbyoReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "Senbyo";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }

    public class ZomeReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "Zome";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
    

}