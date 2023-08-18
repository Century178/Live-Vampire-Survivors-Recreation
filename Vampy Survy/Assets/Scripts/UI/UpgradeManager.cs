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
    private int[] GetRandomUpgradeIndex(int amt)
    {
        if (amt > upgrades.Length) { Debug.LogError("NOT ENOUGH UPGRADES FOR SLOTS"); return new int[0]; }
        int currentWeight = GetTotalWeight();
        int[] indexes = new int[amt];
        for(int i = 0; i < amt; i++) { indexes[i] = -1; }
        for(int i = 0; i < amt; i++)
        {
            int cWeight = Random.Range(0, currentWeight);
            int index = 0;
            while (cWeight >= 0)
            {
                for (int j = 0; j < i; j++) { if (indexes[j] == index) continue; }
                cWeight -= upgrades[index].weight;
                if (cWeight <= 0) { indexes[i] = index; currentWeight -= upgrades[index].weight; break; }
                index++;
                index %= upgrades.Length;
            }
        }
        return indexes;
    }
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
