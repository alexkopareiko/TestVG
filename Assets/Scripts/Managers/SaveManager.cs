using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.TextCore.Text;
using System;

public class SaveManager : MonoBehaviour
{
    private static SaveManager s_Instance;
    public static SaveManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                var singletonObject = new GameObject("SaveManager");
                s_Instance = singletonObject.AddComponent<SaveManager>();
                DontDestroyOnLoad(singletonObject);
            }
            return s_Instance;
        }
    }

    const string k_WinCount = "WinCount";
    const string k_LoseCount = "LoseCount";



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
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void SetupInstance()
    {
        if (Instance == null)
        {
            s_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    #region WinCount

    public int WinCount
    {
        get => PlayerPrefs.GetInt(k_WinCount);
        set => PlayerPrefs.SetInt(k_WinCount, value);
    }

    #endregion

    #region LoseCount

    public int LoseCount
    {
        get => PlayerPrefs.GetInt(k_LoseCount);
        set => PlayerPrefs.SetInt(k_LoseCount, value);
    }

    #endregion

    #region Reset Prefs

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }

    #endregion


}
