using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [SerializeField] private Bullet bulletPrefab;
    private Queue<Bullet> bullets = new Queue<Bullet>();

    [SerializeField] private GameObject splatterFXPrefab, gunSparkFxPrefab;
    private Queue<GameObject> splatterFXList = new Queue<GameObject>();
    private Queue<GameObject> gunSparkFXList = new Queue<GameObject>();

    // public static ObjectPool instance;
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        CreatePool();
    }

    private void CreatePool()
    {
        for (int i = 0; i < 100; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, transform);
            bullets.Enqueue(bullet);
            bullet.gameObject.SetActive(false);
        }

        for (int i = 0; i < 10; i++)
        {
            GameObject splatterfx = Instantiate(splatterFXPrefab, transform);
            splatterFXList.Enqueue(splatterfx);
            splatterfx.SetActive(false);
        }

        for (int i = 0; i < 25; i++)
        {
            GameObject sparkFx = Instantiate(gunSparkFxPrefab, transform);
            gunSparkFXList.Enqueue(sparkFx);
            sparkFx.SetActive(false);
        }
    }

    public Bullet GetBullet()
    {
        Bullet bullet = bullets.Dequeue();
        bullet.gameObject.SetActive(true);
        bullets.Enqueue(bullet);
        return bullet;
    }

    public GameObject GetSplatterFX()
    {
        GameObject splatterfx = splatterFXList.Dequeue();
        splatterfx.SetActive(false);
        splatterfx.SetActive(true);
        splatterFXList.Enqueue(splatterfx);
        return splatterfx;
    }


    public GameObject GetGunSparkFX()
    {
        GameObject sparkFx = gunSparkFXList.Dequeue();
        sparkFx.SetActive(false);
        sparkFx.SetActive(true);
        gunSparkFXList.Enqueue(sparkFx);
        return sparkFx;
    }
}
