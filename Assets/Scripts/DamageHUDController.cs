using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHUDController : MonoBehaviour
{
    Dictionary<CentipedeSegment, HealthHUD> segmentHealthHUD;
    [SerializeField] private HealthHUD healthHUDPrefab;
    public static Action<CentipedeSegment> OnTakeDamage;
    public static DamageHUDController Instance;

    private void Awake()
    {
        segmentHealthHUD = new Dictionary<CentipedeSegment, HealthHUD>();
        Instance = this;
        OnTakeDamage = null;
        OnTakeDamage += UpdateHealth;
    }

    public static void AddHealthHUD(CentipedeSegment segment)
    {
        HealthHUD healthHUD = Instantiate(Instance.healthHUDPrefab, segment.transform);
        Instance.segmentHealthHUD.Add(segment, healthHUD);
    }

    private void UpdateHealth(CentipedeSegment segment)
    {
        segmentHealthHUD[segment].UpdateHealth(segment.Health);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
