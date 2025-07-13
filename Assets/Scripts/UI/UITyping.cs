using System.Collections;
using System.Collections.Generic;
using RSK.Controls;
using TMPro;
using UnityEngine;

namespace RSK.UI 
{
    public class UITyping : MonoBehaviour
    {
        private TextMeshProUGUI _asset;
        [SerializeField] PlayerTyping playerTyping;

        private void Awake()
        {
            _asset = GetComponent<TextMeshProUGUI>();   
        }

        private void Update()
        {
            string typedItem = playerTyping.getTypedItem();
            if (_asset.text != typedItem)
            {
                _asset.text = typedItem;
            }
            
        }
    }
}
