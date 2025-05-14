using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    private Dictionary<UpgradeStatType, float> stats = new();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        stats[UpgradeStatType.Damage] = 1;
        stats[UpgradeStatType.FireRate] = 1;
        stats[UpgradeStatType.BulletSpeed] = 10;
        stats[UpgradeStatType.ForwardShooting] = 1;
        stats[UpgradeStatType.backwardsShooting] = 0;
        stats[UpgradeStatType.SidewayShooting] = 0;
        stats[UpgradeStatType.diagonalShooting] = 0;
    }

    public void ApplyUpgrade(UpgradeStatType statType, float increment)
    {
        if (stats.ContainsKey(statType))
            stats[statType] += increment;
    }

    public IUpgradeHandler GetHandler() => new UpgradeHandler(stats);

    private class UpgradeHandler : IUpgradeHandler
    {
        private Dictionary<UpgradeStatType, float> statsRef;

        public UpgradeHandler(Dictionary<UpgradeStatType, float> stats)
        {
            statsRef = stats;
        }

        public float GetStat(UpgradeStatType statType) => statsRef.ContainsKey(statType) ? statsRef[statType] : 0;
        public void ApplyUpgrade(UpgradeStatType statType, float increment)
        {
            if (statsRef.ContainsKey(statType))
                statsRef[statType] += increment;
        }
    }
}
