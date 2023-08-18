using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int _experience;
    public int experience { private set { _experience = value; } get { return _experience; } }
    private int currentLevelRequirement;
    private int currentLevel = 0;
    #region leveling
    public void AddExperience(int amt)
    {
        experience += amt;
        if (experience >= currentLevelRequirement)
        {
            experience -= currentLevelRequirement;
            
            LevelUp();
        }
    }
    public void CalculateLevelRequirement()
    {
        //Modify equation for the experience curve
        currentLevelRequirement = 100 + 2 * (int)Mathf.Pow(currentLevel, 1.5f);
    }
    public void LevelUp()
    {
        UpgradeManager.instance.UpdateUpgrades();

        UpgradeManager.instance.ShowUpgrades();
        currentLevel++;
        CalculateLevelRequirement();

    }
    #endregion
}
