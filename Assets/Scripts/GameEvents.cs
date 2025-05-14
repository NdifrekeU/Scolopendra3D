
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static Action OnEnemyDie;
    public static Action OnPlayerDie;
    public static Action DoShowUpgradeUI, OnUpgrade;
    public static Action<Vector3> OnShootBullet;
    public static Action<Vector3> OnShootTarget;
    public static Action OnDestroyBodyPart;
    public static GameEvents Instance;

    private void Awake()
    {
        Instance = this;
        OnEnemyDie = null;
        OnPlayerDie = null;
        OnShootBullet = null;
        OnShootTarget = null;
        DoShowUpgradeUI = null;
        OnUpgrade = null;
        OnDestroyBodyPart = null;
    }

}
