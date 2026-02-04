using UnityEngine;
using System;
using System.Collections;
public class EnemyMovement : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    public int currentHealth;

    public static event Action<int> OnEnemyKilled;

    [SerializeField] float speed;
    Animator anim;
    bool canMove;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canMove = true;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //if (GameManager.Instance.status == GameStatus.GamePaused) return;

        if (canMove)
        {
            rb.linearVelocity = new Vector2(-1, transform.position.y) * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (rb.linearVelocity != Vector2.zero)
        {
            anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canMove = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMove = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Despawn()
    {
        anim.SetTrigger("Kill");
        StartCoroutine(timeBeforeReload());
    }

    IEnumerator timeBeforeReload()
    {
        yield return new WaitForSeconds(2f);
        OnEnemyKilled?.Invoke(maxHealth);
        Destroy(gameObject);
    }
}
