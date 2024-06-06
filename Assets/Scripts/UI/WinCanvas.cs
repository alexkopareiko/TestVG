using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinCanvas : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _menuButton;

    private void Start()
    {
        _playButton.onClick.AddListener(Play);
        _menuButton.onClick.AddListener(Menu);
    }

    private void Play()
    {
        GameManager.Instance.PauseGame(false);
        GameManager.Instance.StartLevel();
    }

    private void Menu()
    {
        SceneManager.LoadScene("Menu");
        GameManager.Instance.PauseGame(false);
    }
}
