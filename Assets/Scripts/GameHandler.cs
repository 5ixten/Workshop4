using System;
using UnityEngine;
using TMPro;

public class GameHandler : MonoBehaviour
{
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
    }

    private void Update()
    {
        _infoText.text = "Keys: " + Keys + "\n" + "Health: " + Health;
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
            SceneHandler.Instance.LoadScene("GameScene");
        }
    }
}
