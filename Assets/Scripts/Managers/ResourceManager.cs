using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceManager : MonoBehaviour
{
    private static ResourceManager s_Instance;
    public static ResourceManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                var singletonObject = new GameObject("ResourceManager");
                s_Instance = singletonObject.AddComponent<ResourceManager>();
                DontDestroyOnLoad(singletonObject);
            }
            return s_Instance;
        }
    }

    private List<GameObject> _features = new();

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (s_Instance != this)
        {
            Destroy(gameObject);
        }

        ReadResources();
    }


    private void ReadResources()
    {
        LoadFeatures();
    }


    private void LoadFeatures()
    {
        _features = Resources.LoadAll<GameObject>("Features").ToList();
    }

    public GameObject GetFeature(string name)
    {
        GameObject feature = _features.Where(x => x.name == name).FirstOrDefault();
        return feature;
    }
}
