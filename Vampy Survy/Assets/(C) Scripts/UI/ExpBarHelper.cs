using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBarHelper : MonoBehaviour
{
    public static ExpBarHelper Instance { get; private set; }
    public Image ExpBar;
    
    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;
    }

    /*Fills the exp bar with an amount between 0f and 1f*/
    public void  UpdateExpBar(float amt)
    {
        ExpBar.fillAmount = amt;
    }
}