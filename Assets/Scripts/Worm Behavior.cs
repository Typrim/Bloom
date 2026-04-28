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
        //dead
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (attackTimer < 0)
        {
            animator.SetBool("attacking", true);
            attackTimer = ATTACK_COOLDOWN;
        } else
        {
            attackTimer -= Time.deltaTime;
        }
    }

    public void stopAttack()
    {
        animator.SetBool("attacking", false);
    }
}
