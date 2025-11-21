using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private float _lastJump;
    
    [SerializeField] private LayerMask _groundLayer;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
        
        Vector2 moveInput = InputManager.Instance.MoveDirection;
        float xVelocity = moveInput.x * 5;
        
        Vector2 newVelocity = new Vector2(xVelocity, _rb.linearVelocityY);
        if (_isGrounded && moveInput.y > 0 && Time.time - 0.25f > _lastJump)
        {
            _lastJump = Time.time;
            newVelocity.y = 6;
        }
        
        _rb.linearVelocity = newVelocity;
    }

    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 5, _groundLayer);

        _isGrounded = hit.collider != null;
    }
}
