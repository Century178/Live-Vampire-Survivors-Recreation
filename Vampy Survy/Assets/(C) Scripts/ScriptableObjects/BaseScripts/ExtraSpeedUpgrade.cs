using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Speed", menuName = "ScriptableObjects/Speed")]
public class ExtraSpeedUpgrade : UpgradeBase
{
    [SerializeField] private float speedMulti = 1.5f;
    public override void Upgrade()
    {
        Player.Instance.moveSpeed *= speedMulti;
    }
}
