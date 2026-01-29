using UnityEngine;

public class Bush : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Despawn()
    {
        Destroy(gameObject);
    }
}
