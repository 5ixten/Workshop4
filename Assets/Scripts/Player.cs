using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health { get; private set; }
    
    void Start()
    {
        Health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
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
