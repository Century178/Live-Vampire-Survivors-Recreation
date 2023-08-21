using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Damage", menuName = "ScriptableObjects/Damage")]
public class ExtraDamagePower : UpgradeBase
{
    [SerializeField] private float damageMulti = 1.5f;
    public override void Upgrade()
    {
        AutoaimGun.instance.damageMulti *= damageMulti;
    }
}
