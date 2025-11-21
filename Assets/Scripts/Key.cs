using System;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameEvent _keyPickedUp;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            _keyPickedUp.TriggerEvent();
            Destroy(gameObject);
        }
    }
}
