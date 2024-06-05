using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager s_Instance;

    public static SpawnManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                var go = ResourceManager.Instance.GetFeature("SpawnManager");
                var instantiatedGO = Instantiate(go);
                s_Instance = instantiatedGO.GetComponent<SpawnManager>();
                //DontDestroyOnLoad(instantiatedGO);
            }
            return s_Instance;
        }
    }

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<GameObject> _placesToSpawn = new List<GameObject>();


    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (s_Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public void SpawnEnemies()
    {
        int count = GameManager.Instance.level;
        for (int i = 0; i < count; i++)
        {
            Vector3 placeToSpawn = _placesToSpawn[UnityEngine.Random.Range(0, _placesToSpawn.Count)].transform.position;
            Instantiate(_enemyPrefab, placeToSpawn, Quaternion.identity);
        }
    }

}