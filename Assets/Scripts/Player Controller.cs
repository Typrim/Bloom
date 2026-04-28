using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float HORIZONTAL_SPEED = .0015f;
    private const float JUMP_FORCE = 300;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private bool grounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        Vector3 updatedPosition = transform.position;
        if (Keyboard.current.aKey.isPressed)
        {
            updatedPosition.x -= HORIZONTAL_SPEED;
            spriteRenderer.flipX = true;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            updatedPosition.x += HORIZONTAL_SPEED;
            spriteRenderer.flipX = false;
        }
        transform.position = updatedPosition;
        if (Keyboard.current.wKey.wasPressedThisFrame && grounded)
        {
            rigidbody.AddForce(new Vector2(rigidbody.linearVelocity.x, JUMP_FORCE));
        }

        //attack
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            
        }
    }

    void OnCollisionEnter2D(Collision2D collidingObject)
    {
        if (collidingObject.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D collidingObject)
    {
        if (collidingObject.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
