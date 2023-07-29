using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private Button _newGameButton;
    private Button _exitButton;

    private void Start()
    {
        _newGameButton = GameObject.Find("NewGameButton").GetComponent<Button>();
        _exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        _newGameButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));
        _exitButton.onClick.AddListener(Application.Quit);
    }
}
