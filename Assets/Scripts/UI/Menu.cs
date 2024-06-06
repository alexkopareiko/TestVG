using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _winCount;
    [SerializeField] private TMP_Text _loseCount;

    private void Start()
    {
        _playButton.onClick.AddListener(Play);
        _exitButton.onClick.AddListener(Exit);

        _winCount.text = $"Wins {SaveManager.Instance.WinCount}";
        _loseCount.text = $"Loses {SaveManager.Instance.LoseCount}";

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Play()
    {
        SceneManager.LoadScene("Game");
    }

    private void Exit()
    {
        Application.Quit();
    }
}
