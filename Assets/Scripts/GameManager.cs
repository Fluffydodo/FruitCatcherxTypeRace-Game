using System.Collections;
using System.Collections.Generic;
using RSK.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    [SerializeField] private float lifeCounter = 10f;
    [SerializeField] private PlayerInput playerInput;
    private UIManager uiManager;

    private void Awake()
    {
        Instance = this;
        uiManager = UIManager.instance;
    }

    public void TakeDamage() 
    {
        lifeCounter--;
        uiManager.UpdateLife(lifeCounter);
        CheckDeath();
    }

    private void CheckDeath() 
    {
        if (lifeCounter <= 0) 
        {
            uiManager.OnDeath();
            Time.timeScale = 0f;
            if (playerInput != null)
            {
                playerInput.enabled = false;
            }
        }
    } 

    public void LoadGame() 
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log("click");
        Time.timeScale = 1f;
    }

    public void LoadMenu() 
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public float getLifeCounter() 
    {
        return lifeCounter;
    }
}
