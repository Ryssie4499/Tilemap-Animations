using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damagePerHit;
    [SerializeField] float rateAttack;
    float timer;
    GameObject collidedObject;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if (GameManager.Instance.status == GameStatus.GamePaused) return;

        collidedObject = collision.gameObject;

        timer += Time.fixedDeltaTime;
        if(timer >= rateAttack && collision.CompareTag("Player"))
        {
            transform.GetComponentInParent<Animator>().SetTrigger("IsAttacking");
            HitItem();
            timer = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedObject = null;
    }

    public void HitItem()
    {
        if (collidedObject == null) return;

        collidedObject.gameObject.TryGetComponent(out IDamageable damageable);
        collidedObject.gameObject.TryGetComponent(out PlayerMovement player);

        if (damageable == null) return;

        damageable.TakeDamage(damagePerHit);

        if(player== null) return;

        if(player.currentHealth <= 0)
        {
            StartCoroutine(timeBeforeDespawn(damageable));
        }
    }
    IEnumerator timeBeforeDespawn(IDamageable damageable)
    {
        yield return new WaitForSeconds(0.2f);
        damageable.Despawn();
    }
}
