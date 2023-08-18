
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UpgradeBase : ScriptableObject
{
    //Upgrade values with private setters(disabling further modification) and public getters
    [SerializeField] private string _upgradeName;
    public string name { get { return _upgradeName; } private set { } }

    [SerializeField] private string _upgradeDescription;
    public string description { get { return _upgradeDescription; } private set { } }

    [SerializeField] private Sprite _upgradeSprite;
    public Sprite sprite { get { return _upgradeSprite; } private set { } }

    [SerializeField] private int _weight;
    public int weight {  get { return _weight; } private set {} }
    //Base upgrade function, throws error as its not meant to be called without being overriden
    public virtual void Upgrade()
    {
        Debug.LogError("NO UPGRADE DEFINED");
    }
}
