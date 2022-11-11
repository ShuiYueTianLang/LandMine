using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Jacky
{
    public class AssetService
    {
        public static GameObject LoadAsset(string assetName)
        {
            var obj = Resources.Load(assetName);
            return Object.Instantiate(obj) as GameObject;
        }

        public static void ReleaseAsset(GameObject go)
        {
            
        }
    }
}