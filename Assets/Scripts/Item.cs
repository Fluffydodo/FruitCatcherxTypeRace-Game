using System.Collections;
using System.Collections.Generic;
using RSK.Controls;
using RSK.UI;
using UnityEngine;

namespace RSK 
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemInfo itemInfo;

        BoxCollider2D boxCollider;

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            if (collision.gameObject.layer == 6)
            {
                Destroy(this.gameObject);
                
                UIManager.instance.InstantiateTypingPrefab(itemInfo);
            }

            if (collision.gameObject.tag == "floor") 
            {
                GameManager.Instance.TakeDamage();
                Destroy(this.gameObject);   
            }
        }
    }
}
    
