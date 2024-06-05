using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private ActorStats _actorStats;

    private void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _actorStats = GetComponent<ActorStats>();

        _agent.speed = _speed;
    }

    private void Update()
    {
        if (_target == null)
        {
            FindPlayer();
            return;
        }

        _agent.SetDestination(_target.position);
        _animator.SetFloat("Speed", _agent.velocity.magnitude);

        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _animator.SetFloat("Speed", 0f);
            Attack();
        }
    }

    private void FindPlayer()
    {
        int maxColliders = 300;
        Collider[] hitColliders = new Collider[maxColliders];
        float enemyRadius = 50f;
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, enemyRadius, hitColliders);

        if (numColliders < 1)
            return;

        for (int i = 0; i < numColliders; i++)
        {
            if (hitColliders[i].CompareTag("Player"))
            {
                _target = hitColliders[i].transform;
                break;
            }
        }
    }

    private void Attack()
    {
        ActorStats stats = Helpers.CheckOnComponent<ActorStats>(_target.gameObject);
        if (stats != null)
        {
            stats.TakeDamage(_actorStats.damage);
            _animator.SetTrigger("Attack");
        }
        _target = null;
    }
}
