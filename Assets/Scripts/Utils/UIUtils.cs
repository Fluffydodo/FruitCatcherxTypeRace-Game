using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUtils : MonoBehaviour
{
    public bool isOpen;
    public GameObject ui;

    public virtual void Awake()
    {
        ui.SetActive(false);
    }
    public virtual void ShowUI()
    {
        ui.SetActive(true);
    }
    public virtual void HideUI()
    {
        ui.SetActive(false);
    }
}
