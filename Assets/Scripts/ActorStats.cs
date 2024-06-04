using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _detectZoneRange;

    public float health => _health;
    public float maxHealth => _maxHealth;
    public float damage => _damage;
    public float detectZoneRange => _detectZoneRange;

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

}
