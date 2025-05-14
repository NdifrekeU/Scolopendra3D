using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;
    public int damage = 1;

    void Start()
    {
        Invoke(nameof(Hide), lifeTime);
        GameEvents.OnUpgrade += () => speed = Mathf.RoundToInt(UpgradeManager.Instance.GetHandler().GetStat(UpgradeStatType.BulletSpeed));

    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        var dmgable = other.GetComponent<IDamageable>();
        if (dmgable != null)
        {
            dmgable.TakeDamage(damage);
            gameObject.SetActive(false);
            GameEvents.OnShootTarget?.Invoke(transform.position);
        }
    }
}
