using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RSK.UI 
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] private ItemInfo itemInfo;
        [SerializeField] private GameObject textGameObject;
        private TextMeshProUGUI textMeshPro;

        private void Awake()
        {
            textMeshPro = textGameObject.GetComponent<TextMeshProUGUI>();
        }

        private void OnDestroy()
        {
            UIManager.instance.UpdateScore(itemInfo.points);
        }
    }
}
    
