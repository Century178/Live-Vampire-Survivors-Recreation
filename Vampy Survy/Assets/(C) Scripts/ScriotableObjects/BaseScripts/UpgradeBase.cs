using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class UpgradeBase : ScriptableObject
{
    //Upgrade values with private setters(disabling further modification) and public getters
    [SerializeField] private string _upgradeName;
    public string Name => _upgradeName;

    [SerializeField] private string _upgradeDescription;
    public string Description => _upgradeDescription;

    [SerializeField] private Sprite _upgradeSprite;
    public Sprite Sprite => _upgradeSprite;

    [SerializeField] private int _weight;
    public int Weight => _weight;

    //Base upgrade function, throws error as its not meant to be called without being overriden
    public abstract void Upgrade();
}
