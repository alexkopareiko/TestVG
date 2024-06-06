using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager s_Instance;
    public static UIManager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                var go = ResourceManager.Instance.GetFeature("UIManager");
                var instantiatedGO = Instantiate(go);
                s_Instance = instantiatedGO.GetComponent<UIManager>();
            }
            return s_Instance;
        }
    }

    [SerializeField] private GameObject _winCanvas;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _playCanvas;

    private List<GameObject> _canvases = new List<GameObject>();

    private void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        else if (s_Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        _canvases.Add(_winCanvas);
        _canvases.Add(_gameOverCanvas);
        _canvases.Add(_playCanvas);

        ShowPlayCanvas();
    }

    private void ShowCanvas(GameObject canvas)
    {
        foreach (var item in _canvases)
            item.SetActive(item == canvas);
    }

    public void ShowWinCanvas()
    {
        ShowCanvas(_winCanvas);
    }

    public void ShowGameOverCanvas()
    {
        ShowCanvas(_gameOverCanvas);
    }

    public void ShowPlayCanvas()
    {
        ShowCanvas(_playCanvas);
    }
}
