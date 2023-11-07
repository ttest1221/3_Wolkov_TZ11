using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Text _gameOverScore;
    [SerializeField] private Text _gameOverBestScore;
    [SerializeField] private Text _repeats;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private CameraMovement _gameSpeed;

    public GameObject startText;
    public bool gameStarted = false;
    public int speed;
    public int score;
    public int bestScore;
    public float startTimer;
    public int repeats;

    private IEnumerator SpeedUp()
    {
        yield return new WaitForSeconds(5);
        speed++;
        _gameSpeed.cameraSpeed = speed;
        StartCoroutine(SpeedUp());
    }
    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        Play();
        gameStarted = true;
        startText.SetActive(false);
        speed = 2;
        _gameSpeed.cameraSpeed = speed;
        StartCoroutine(SpeedUp());
    }
    public void ShowGame()
    {
        _gameScreen.SetActive(true);
        _menuScreen.SetActive(false);
        _game.SetActive(true);
        _menu.SetActive(true);
        _pausePanel.SetActive(false);
        TextsUpdate();
    }
    public void HideGame()
    {
        _gameScreen.SetActive(false);
        _menuScreen.SetActive(true);
        _pausePanel.SetActive(false);
    }
    public void PauseClick()
    {
        _pausePanel.SetActive(true);
        Pause();
    }
    public void ResumeClick()
    {
        _pausePanel.SetActive(false);
        Play();
        TextsUpdate();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Play()
    {
        Time.timeScale = 1f;
    }
    public void TextsUpdate()
    {
        _scoreText.text = score.ToString();
        _gameOverScore.text = "Текущий результат " +  score.ToString();
        _gameOverBestScore.text = "Лучший результат " + bestScore.ToString();
        _repeats.text = "Количество попыток " + repeats.ToString();
    }
    public void GameOver()
    {
        Obstacle[] platforms = FindObjectsByType<Obstacle>(FindObjectsSortMode.None);
        for (int i = 0; i < platforms.Length; i++)
            Destroy(platforms[i].gameObject);
        _gameScreen.SetActive(false);
        gameStarted = false;
        repeats++;
        if (bestScore < score)
            bestScore = score;
        TextsUpdate();
        _menuScreen.SetActive(true);
        _resultPanel.SetActive(true);
        score = 0;
    }
}
