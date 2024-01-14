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
            //Replace with the Asset Name from your unity project
            string model_name = "Anomea";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
    
    public class NagiReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            //Replace with the Asset Name from your unity project
            string model_name = "Nagi";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }
    
    public class ZomeReplacement : BodyReplacementBase
    {
        protected override GameObject LoadAssetsAndReturnModel()
        {
            //Replace with the Asset Name from your unity project
            string model_name = "Zome";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }
    }

}
