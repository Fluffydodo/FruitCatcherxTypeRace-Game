using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private float score = 0f;
    private TextMeshProUGUI m_TextMeshProUGUI;

    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(float points) 
    {
        score += points;
        string formattedText = score.ToString("Score: 000000000000");
        m_TextMeshProUGUI.text = formattedText;
    }

}
