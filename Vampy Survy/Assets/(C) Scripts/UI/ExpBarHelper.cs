using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExpBarHelper : MonoBehaviour
{
    public static ExpBarHelper instance;
    public Image expBar;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    /*Fills the exp bar with an amount between 0f and 1f*/
    public void  UpdateExpBar(float amt)
    {
        expBar.fillAmount = Mathf.Clamp01(amt);
    }
}
