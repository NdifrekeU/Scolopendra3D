using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private float duration, strength;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.OnShootBullet += DoShake;
    }

    private void DoShake(Vector3 position)
    {
        transform.DOShakePosition(duration, strength);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
