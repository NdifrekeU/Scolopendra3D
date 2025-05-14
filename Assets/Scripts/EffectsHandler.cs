using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnShootTarget += ShowHitSplatter;
        GameEvents.OnShootBullet += ShowGunSpark;
    }

    private void ShowHitSplatter(Vector3 pos)
    {
        GameObject fx = ObjectPool.Instance.GetSplatterFX();
        fx.transform.position = pos;
    }

    private void ShowGunSpark(Vector3 pos)
    {
        GameObject fx = ObjectPool.Instance.GetGunSparkFX();
        fx.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
