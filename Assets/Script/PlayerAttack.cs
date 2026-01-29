using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] int damagePerHit; //danno al colpo
    GameObject collidedObject;

    private void Update()
    {
        if (collidedObject == null) return; //se l'oggetto con cui sto collidendo è nullo, non faccio niente

        //se non è nullo e clicco F per attaccare
        if (Input.GetKeyDown(KeyCode.F))
        {

            //mi prendo l'interfaccia e il Bush
            collidedObject.gameObject.TryGetComponent(out IDamageable damageable);
            collidedObject.gameObject.TryGetComponent(out Bush bush);

            //se non esiste l'interfaccia o il bush sull'oggetto triggerato, skippo
            if (damageable == null || bush == null) return;

            //gli faccio danno
            damageable.TakeDamage(damagePerHit);

            //sennò lo distruggo
            if (bush.currentHealth <= 0)
                StartCoroutine(timeBeforeDespawn(damageable));
        }
    }

    IEnumerator timeBeforeDespawn(IDamageable damageable)
    {
        //dopo 0.2 secondi despawno il bush
        yield return new WaitForSeconds(0.2f);
        damageable.Despawn();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collidedObject = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedObject = null;
    }
}
