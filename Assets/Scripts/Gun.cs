using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// PUBLIC FIELDS
    /// </summary>
    public Transform[] frontFirePoints, diagonalFirePoints, backFirePoints, siewaysFirePoints;
    public GameObject bulletPrefab;

    /// <summary>
    /// SERIALIZED FIELDS
    /// </summary>
    [SerializeField] private float fireRate = 2;


    /// <summary>
    /// PRIVATE FIELDS
    private IUpgradeHandler upgradeHandler;
    private bool _canShoot = true;
    private float nextFire;
    private int numOfFrontFirePoints = 1, numOfDiagonalFirePoints, numOfBackFirePoints, numOfSidewaysFirePoints;
    /// </summary>




    // Start is called before the first frame update
    void Start()
    {
        upgradeHandler = UpgradeManager.Instance.GetHandler();

        GameEvents.OnUpgrade += () => SetShooting(true);
        GameEvents.OnUpgrade += () => ApplyUpgrade();
        GameEvents.DoShowUpgradeUI += () => SetShooting(false);


    }

    public void SetShooting(bool set)
    {
        _canShoot = set;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            SetShooting(true);
        }

        if (_canShoot == false)
            return;

        if (Time.time >= nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            HandleShooting(frontFirePoints, numOfFrontFirePoints);
            HandleShooting(backFirePoints, numOfBackFirePoints);
            HandleShooting(siewaysFirePoints, numOfSidewaysFirePoints);
            HandleShooting(diagonalFirePoints, numOfDiagonalFirePoints);
        }
    }

    void HandleShooting(Transform[] firePoints, int count)
    {
        for (int i = 0; i < count; i++)
        {
            firePoints[i].gameObject.SetActive(true);
            ShootWithVector(firePoints[i].position, firePoints[i].rotation);
            GameEvents.OnShootBullet?.Invoke(firePoints[i].position);
        }
    }

    private void ShootWithVector(Vector3 position, Quaternion rotation)
    {
        Bullet bullet = ObjectPool.Instance.GetBullet();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.damage = Mathf.RoundToInt(upgradeHandler.GetStat(UpgradeStatType.Damage));
    }

    void ApplyUpgrade()
    {
        numOfBackFirePoints = Mathf.RoundToInt(upgradeHandler.GetStat(UpgradeStatType.backwardsShooting));
        numOfFrontFirePoints = Mathf.RoundToInt(upgradeHandler.GetStat(UpgradeStatType.ForwardShooting));
        numOfDiagonalFirePoints = Mathf.RoundToInt(upgradeHandler.GetStat(UpgradeStatType.diagonalShooting));
        numOfSidewaysFirePoints = Mathf.RoundToInt(upgradeHandler.GetStat(UpgradeStatType.SidewayShooting));
        fireRate = Mathf.RoundToInt(upgradeHandler.GetStat(UpgradeStatType.FireRate));


    }
}
