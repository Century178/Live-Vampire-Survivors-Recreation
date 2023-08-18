using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    #region Singleton
    private static UpgradeManager _instance;
    public static UpgradeManager instance { private set { }get { return _instance; }  }
    #endregion
    
    #region UI
    [SerializeField] private UpgradeSlot[] upgradeSlots;
    [SerializeField] private CanvasGroupHelper canvasGroupHelper;
    #endregion
    #region Upgrade Info
    [SerializeField] private UpgradeBase[] upgrades;
    
    #endregion 
    // Start is called before the first frame update
    void Awake()
    {
        _instance=this;
    }
    private void Start()
    {
        for(int i = 0; i < upgradeSlots.Length; i++) { upgradeSlots[i].index = i; }
    }
    //Update Upgrade UI
    public void UpdateUpgrades()
    {
        int[] upgradeIndexes = GetRandomUpgradeIndex(upgradeSlots.Length);
        for(int i = 0; i < upgradeSlots.Length; i++)
        {
            upgradeSlots[i].UpdateUpgradeUI(upgrades[upgradeIndexes[i]]);
        }
    }
    public void ShowUpgrades()
    {
        canvasGroupHelper.SetOn();
    }
    public void CloseUpgrades()
    {
        canvasGroupHelper.SetOff();
    }
    #region private helper functions
    /*Get's amt weighted number of unique indexes from the upgrades list*/
    private int[] GetRandomUpgradeIndex(int amt)
    {
        if (amt > upgrades.Length) { Debug.LogError("NOT ENOUGH UPGRADES FOR SLOTS"); return new int[0]; }
        int currentWeight = GetTotalWeight();
        int[] indexes = new int[amt];
        /*Defaults values to -1 to avoid skipping index 0*/
        for(int i = 0; i < amt; i++) { indexes[i] = -1; }
        for(int i = 0; i < amt; i++)
        {
            /*Generate a random weight*/
            int cWeight = Random.Range(0, currentWeight);
            int index = 0;
            while (cWeight >= 0)
            {
                /*If the index has been selected skip this index*/
                for (int j = 0; j < i; j++) { if (indexes[j] == index) continue; }
                
                cWeight -= upgrades[index].weight;
                /*If weight is 0 select this index and repeat selection process*/
                if (cWeight <= 0) { indexes[i] = index; currentWeight -= upgrades[index].weight; break; }
                /*Prevents overflow in case of unforeseen miscalculation */
                index++;
                index %= upgrades.Length;
            }
        }
        return indexes;
    }
    //Get total weight from all upgrades
    private int GetTotalWeight()
    {
        int total = 0;
        for(int i = 0; i < upgrades.Length; i++)
        {
            total += upgrades[i].weight;
        }
        return total;
    }
    #endregion
}
