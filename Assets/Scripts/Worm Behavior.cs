using UnityEngine;

public class WormBehavior : MonoBehaviour
{
    private const float ATTACK_COOLDOWN = 5;
    private int health;
    private Animator animator;
    private float attackTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer < 0)
        {
            animator.SetBool("attacking", true);
            attackTimer = ATTACK_COOLDOWN;
        } else
        {
            attackTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void StopAttack()
    {
        animator.SetBool("attacking", false);
    }
}
