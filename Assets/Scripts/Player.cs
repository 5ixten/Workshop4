using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x,
            Camera.main.transform.position.y,
            Camera.main.transform.position.z);
    }
}
