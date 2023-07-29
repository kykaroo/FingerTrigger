using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : ButtonsController
{
    private TextMeshProUGUI _timerUiText;
    private TextMeshProUGUI _scoreUiText;
    private Button _backButton;
    private Button _exitButton;
    private float _timer;
    private int _scoreCount;
    private void Start()
    {
        _timerUiText = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        _scoreUiText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        _backButton = GameObject.Find("BackButton").GetComponent<Button>();
        _exitButton = GameObject.Find("ExitButton").GetComponent<Button>();
        
        _backButton.onClick.AddListener(() => SceneManager.LoadScene("MainMenu"));
        _exitButton.onClick.AddListener(Application.Quit);
        
        _timerUiText.text = "0";
        _scoreUiText.text = "0";
        InitializeButtons();
        _scoreCount = -3;
    }

    private void Update()
    {
        UpdateTimer();
        if (activeButtonCount >= 3) return;
        var rnd = Random.Range(0, buttonList.Count);
        Debug.Log($"Update rnd={rnd} last={lastDisabledButton}");
        if (rnd == lastDisabledButton) return;
        if (EnableButton(rnd) == false) return;
        _scoreCount++;
        Debug.Log("addScore");
        _scoreUiText.text = $"{_scoreCount}";
    }

    private void UpdateTimer()
    {
        _timer += Time.deltaTime;
        _timerUiText.text = $"{(int)_timer}";
    }
}
