using System.Collections;
using System.Collections.Generic;
using RSK.Controls;
using TMPro;
using UnityEngine;

namespace RSK.UI
{
    public class UIManager : MonoBehaviour, IState
    {
        [SerializeField] private GameObject itemUI, lifeUI, loseScreen;
        private Score _score;
        private RectTransform rt;

        public static UIManager instance;


        private void Awake()
        {
            instance = this;
            rt = GetComponent<RectTransform>();
           
            _score = GetComponentInChildren<Score>();
            
        }

        private void Start()
        {
            UpdateLife(GameManager.Instance.getLifeCounter());
        }

        public void UpdateScore(float points)
        {
            _score.UpdateScore(points);
        }

        public void UpdateLife(float life) 
        {
            string formattedText = life.ToString("Life: 00");
            lifeUI.GetComponent<TextMeshProUGUI>().text = formattedText;
        }

 

        public void InstantiateTypingPrefab(ItemInfo itemInfo) 
        {
            Vector3 vector3 = new Vector3(Random.Range(rt.rect.xMin, rt.rect.xMax),
                              Random.Range(rt.rect.yMin, rt.rect.yMax), 0);
            WordMatch.instance.addUIItem(Instantiate(itemInfo.itemUIPrefab, vector3+ rt.transform.position,
                              Quaternion.identity, itemUI.transform), itemInfo);
        }

        public void OnDeath()
        {
            loseScreen.SetActive(true);
        }
    }
}
