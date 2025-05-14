using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UpgradeData : ScriptableObject
{
    public UpgradeStatType upgradeStatType;
    public string upgradeName, upgradeDesc;
    public int increment;
}
