using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Reflection;


namespace Utils
{
    [CreateAssetMenu(fileName = nameof(AssetsStorage), menuName = "Strategy/ " + nameof(AssetsStorage))]   
    public class AssetsStorage : ScriptableObject
    {
        [SerializeField] private List<GameObject> _assets;

        public GameObject GetAsset(string assetName)
        {
            return _assets.FirstOrDefault(asset => asset.name == assetName);
        }               
    }
}
