using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }

    public int Experience { get; private set; }
    private int currentLevelRequirement;
    private int currentLevel = 0;
    public List<Transform> enemyList;
    #region leveling
    public void AddExperience(int amt)
    {
        Experience += amt;
        if (Experience >= currentLevelRequirement)
        {
            Experience -= currentLevelRequirement;
            
            LevelUp();
        }

        ExpBarHelper.Instance.UpdateExpBar(((float)Experience) / currentLevelRequirement);
    }
    public void CalculateLevelRequirement()
    {
        //Modify equation for the experience curve
        currentLevelRequirement = 100 + 2 * (int)Mathf.Pow(currentLevel, 1.5f);
    }
    public void LevelUp()
    {
        UpgradeManager.Instance.UpdateUpgrades();

        UpgradeManager.Instance.ShowUpgrades();
        currentLevel++;
        CalculateLevelRequirement();

    }
    #endregion
    private void Awake()
    {
        Instance = this;
        enemyList = new List<Transform>();
        CalculateLevelRequirement();
    }
}
