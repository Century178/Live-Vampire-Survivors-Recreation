using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FireRate",menuName = "ScriptableObjects/FireRate")]
public class ExtraFireRateUpgrade : UpgradeBase
{
    [SerializeField] private float fireRateMulti = 0.75f;
    public override void Upgrade()
    {
        AutoaimGun.instance.fireRateMulti *= fireRateMulti;
    }
}
