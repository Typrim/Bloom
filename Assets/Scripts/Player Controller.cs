using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float HORIZONTAL_SPEED = 2.8f;
    private const float JUMP_FORCE = 300;
    private const float DAMAGE = 15;
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool grounded;
    public Transform attackZone;
    public float attackRadius;
    public LayerMask enemyLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        Vector3 updatedPosition = transform.position;
        if (Keyboard.current.aKey.isPressed)
        {
            updatedPosition.x -= HORIZONTAL_SPEED * Time.deltaTime;
            spriteRenderer.flipX = true;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            updatedPosition.x += HORIZONTAL_SPEED * Time.deltaTime;
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
            Attack();
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

    void Attack()
    {
        //play attack animation
        animator.SetBool("attacking", true);
        //detect enemies in range
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackZone.position, attackRadius, enemyLayer);
        //damage enemies
        foreach (Collider2D enemy in enemiesHit)
        {
            enemy.GetComponent<WormBehavior>().TakeDamage(DAMAGE);
        }
    }

    public void StopAttack()
    {
        animator.SetBool("attacking", false);
    }

    void OnDrawGizmosSelected()
    {
        //no attack point
        if (attackZone == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackZone.position, attackRadius);
    }
}
