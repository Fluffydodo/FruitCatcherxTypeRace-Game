using System.Collections;
using System.Collections.Generic;
using RSK.UI;
using UnityEngine;

namespace RSK.Controls 
{
    public class WordMatch : MonoBehaviour
    {
        private Dictionary<GameObject, string> keyValuePairs = new Dictionary<GameObject, string>();


        private PlayerTyping playerTyping;
        public static WordMatch instance;

        private void Awake()
        {
            instance = this;
            playerTyping = GetComponent<PlayerTyping>();

        }

        public void addUIItem(GameObject itemUIGameObject, ItemInfo itemInfo) 
        {
            keyValuePairs.Add(itemUIGameObject, itemInfo.name);
        }

        public void removeUIItem(string word) 
        {
            List<GameObject> keysToRemove = new List<GameObject>();

            foreach (KeyValuePair<GameObject, string> pair in keyValuePairs) 
            { 
                if(pair.Value.Equals(word)) 
                {
                    GameObject gameObject = pair.Key;
                    keysToRemove.Add(pair.Key);
                    Destroy(gameObject);
                    
                }
            }

            foreach (GameObject key in keysToRemove)
            {
                keyValuePairs.Remove(key);
            }
        }
    }
}
