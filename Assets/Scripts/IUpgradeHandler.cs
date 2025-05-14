public interface IUpgradeHandler
{
    float GetStat(UpgradeStatType statType);
    void ApplyUpgrade(UpgradeStatType statType, float increment);
}

public enum UpgradeStatType
{
    Damage,
    FireRate,
    ForwardShooting,
    SidewayShooting,
    backwardsShooting,
    diagonalShooting,
    BulletSpeed
}
