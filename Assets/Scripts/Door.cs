using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpen;
    private bool _entered;
    
    [SerializeField] private GameObject _openDoor;
    [SerializeField] private GameObject _closedDoor;
    [SerializeField] private GameEvent _doorEntered;

    void Update()
    {
        _openDoor.SetActive(_isOpen);
        _closedDoor.SetActive(!_isOpen);
    }

    public void UnlockDoor()
    {
        _isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>() && _isOpen && !_entered)
        {
            _doorEntered.TriggerEvent();
            _entered = true;
        }
    }
}
