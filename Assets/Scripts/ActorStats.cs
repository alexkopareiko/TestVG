using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _detectZoneRange;
    [SerializeField] protected Animator _animator;

    public float health => _health;
    public float maxHealth => _maxHealth;
    public float damage => _damage;
    public float detectZoneRange => _detectZoneRange;

    private void OnEnable()
    {
        _health = _maxHealth;
        _animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
        else
        {
            if (_animator != null)
            { 
                _animator.Play("GetHit");
            }
        }
    }

    public virtual void Die()
    {
        if (_animator != null)
        {
            _animator.Play("Die");
        }

        Destroy(gameObject, 2f);
    }

}
