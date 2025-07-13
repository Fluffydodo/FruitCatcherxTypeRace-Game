using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RSK.Controls
{
    public class PlayerTyping : MonoBehaviour
    {
        [SerializeField] private string typedItem = "";
        [SerializeField] private string finishedItem = "";

        private void Awake()
        {
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Return) && !string.IsNullOrEmpty(typedItem))
            {
                finishedItem = typedItem;
                WordMatch.instance.removeUIItem(finishedItem.ToLower());
                typedItem = "";
            }
            else if (Input.GetKeyDown(KeyCode.Backspace) && !string.IsNullOrEmpty(typedItem))
            {
                typedItem = typedItem.Substring(0, typedItem.Length - 1);
            }

            int start = (int)KeyCode.A;
            int end = (int)KeyCode.Z;
            for (int i = start; i <= end; i++)
            {
                if (Input.GetKeyUp((KeyCode)i))
                {
                    KeyCode key = (KeyCode)i;
                    StringBuilder stringBuilder = new StringBuilder(typedItem);
                    stringBuilder.Append(key.ToString());
                    typedItem = stringBuilder.ToString();
                }
            }   
        }


        public String getTypedItem()
        {
            return typedItem;
        }

        public String getFinishedItem() 
        {
            return finishedItem;
        }

        

       


    }
}
