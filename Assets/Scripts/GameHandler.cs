using System;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
    private float _timeLeft;
    
    [SerializeField] private TextMeshProUGUI _infoText;
    
    public static GameHandler Instance { get; private set; }
    public int Keys { get; private set; }
    public int Health { get; private set; }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        Keys = 0;
        Health = 3;
        _timeLeft = 15;
    }

    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        _infoText.text = "Keys: " + Keys + "\n" + "Health: " + Health + "\n" + "Time Left: " + _timeLeft.ToString("0.##");

        if (_timeLeft <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneHandler.Instance.LoadScene("LoseScene");
    }

    public void Win()
    {
        SceneHandler.Instance.LoadScene("WinScene");
    }

    public void TakeKey()
    {
        Keys++;
    }
    
    public void TakeDamage(int damage = 1)
    {
        Health -= damage;

        if (Health <= 0)
        {
            GameOver();
        }
    }
}
