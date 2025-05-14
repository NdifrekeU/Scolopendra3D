using System.Collections.Generic;
using CurvedPathGenerator;
using UnityEngine;

public class CentipedeSegment : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 1;

    /// <summary>
    /// PUBLIC FIELDS
    public int Health => health;
    public float speed = 100;
    public CentipedeController controller;
    /// </summary>


    /// <summary>
    /// PRIVATE FIELDS
    private Transform segmentInFront;
    private bool _canMove = true;
    /// </summary>




    public void Init(CentipedeController controller, Transform seg1)
    {
        this.controller = controller;
        segmentInFront = seg1;
        health = Random.Range(7, 15);
        DamageHUDController.AddHealthHUD(this);
        DamageHUDController.OnTakeDamage?.Invoke(this);

    }

    public void SetMove(bool enabled)
    {
        _canMove = enabled;
    }
    private void Follow()
    {
        if (!_canMove) return;

        if (segmentInFront == null)
            segmentInFront = CentipedeController.instance.GetSegmentInFront(this);

        Vector3 targetPos = segmentInFront.position;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void Update()
    {
        Follow();
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        DamageHUDController.OnTakeDamage?.Invoke(this);
        if (health <= 0)
        {
            controller.KillSegment(this);
        }
    }
}

[CreateAssetMenu]
public class CentipedeData : ScriptableObject
{
    public int healthMin = 7;
    public int healthMax = 15;
    public int speed = 100;
    public float moveInterval = 0.5f;
}