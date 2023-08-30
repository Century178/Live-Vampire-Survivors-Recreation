using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSlot : MonoBehaviour
{
    private UpgradeBase currentUpgrade;
   
    #region UI
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Image iconImage;
    #endregion

    #region debug
    [HideInInspector] public int index;
    #endregion

    public void UpdateUpgradeUI(UpgradeBase info)
    {
        currentUpgrade = info;
        nameText.text = info.Name;
        descriptionText.text = info.Description;
        iconImage.sprite = info.Sprite;
    }

    public void ChooseUpgrade()
    {
        currentUpgrade.Upgrade();
        UpgradeManager.Instance.CloseUpgrades();
    }
}
