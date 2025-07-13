using System.Collections;
using System.Collections.Generic;
using RSK;
using UnityEngine;

namespace RVK 
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private ItemInfo[] itemInfos;
        [SerializeField] private GameObject parent;
        [SerializeField] private float spawnInterval = 3f;
        private float timer;

        private void Update()
        {
            timer +=Time.deltaTime;

            if(timer > spawnInterval) 
            {
                InstantiateItemPrefab();
                timer -= spawnInterval;
            }

        }

        private void InstantiateItemPrefab() 
        {
            if(itemInfos != null) 
            {
                GameObject itemPrefab = itemInfos[Random.Range(0, itemInfos.Length)].itemPrefab;

                Instantiate(itemPrefab, new Vector2(Random.Range(-9f, 9f), 5.2f), Quaternion.identity, parent.transform);
            }
        }

    }
}
