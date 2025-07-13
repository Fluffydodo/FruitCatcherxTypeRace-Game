using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RSK
{
    [CreateAssetMenu(fileName = "New Item", menuName = "New Item")]

    public class ItemInfo : ScriptableObject
    {
        [Header("Item Settings")]
        [Space(15)]
        public new string name;
        public GameObject itemPrefab;
        public GameObject itemUIPrefab;
        public float points;
    }
}
