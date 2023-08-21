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
    private void Update()
    {

    }
    /*Fills the exp bar with an amount between 0f and 1f*/
    public void  UpdateExpBar(float amt)
    {
        Debug.Log("Fill amt: " + amt);
        expBar.fillAmount = amt;
    }
}
