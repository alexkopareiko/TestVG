using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance => s_Instance;
    private static Player s_Instance;

    [SerializeField] private ActorStats _actorStats;

    public ActorStats actorStats => _actorStats;

    private void OnEnable()
    {
        if (s_Instance != null && s_Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        s_Instance = this;
    }
}
