using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour, IObservable<GameStatus>
{
    private const float BASE_GAME_SPEED = 7;
    private List<IObserver<GameStatus>> _observers = new();

    public static GameManager Instance { get; private set; }
    public GameObject playButton;
    public GameObject startGameLabel;
    public TextMeshProUGUI scoreLabel;
    public bool isRunning = false;
    public float gameSpeed = 0;
    public int score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        Button btn = playButton.GetComponent<Button>();
        btn.onClick.AddListener(Play);
    }

    public void Play()
    {
        score = 0;
        gameSpeed = BASE_GAME_SPEED;
        isRunning = true;
        playButton.SetActive(false);
        startGameLabel.SetActive(false);
        NotifySubscribers(GameStatus.Running);
    }

    public void GameOver()
    {
        isRunning = false;
        gameSpeed = 0;
        playButton.SetActive(true);
        startGameLabel.SetActive(true);
        NotifySubscribers(GameStatus.Paused);
    }

    public void IncreaseScore()
    {
        score += 1;
        gameSpeed += 0.1f;
        scoreLabel.text = score.ToString();
    }

    public void Subscribe(IObserver<GameStatus> subscriber)
    {
        _observers.Add(subscriber);
    }

    public void UnSubscribe(IObserver<GameStatus> subscriber)
    {
        _observers.Remove(subscriber);
    }

    public void NotifySubscribers(GameStatus status)
    {
        foreach (var observer in _observers)
        {
            observer.OnUpdate(status);
        }
    }
}