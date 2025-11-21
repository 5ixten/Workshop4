using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private float _lastJump;
    
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
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
        _spriteRenderer.flipX = _rb.linearVelocity.x < 0;
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        if (!_isGrounded)
        {
            _animator.SetTrigger("Fall");
        } 
        else if (Mathf.Abs(_rb.linearVelocity.x) > 1)
        {
            _animator.SetTrigger("Walk");
        }
        else
        {
            _animator.SetTrigger("Idle");
        }
    }

    private void GroundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer);

        _isGrounded = hit.collider != null;
    }
}
