using UnityEngine;
using System;

public class Bush : MonoBehaviour, IDamageable
{
    public static event Action<int> OnItemDestroyed;

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
        OnItemDestroyed?.Invoke(maxHealth);
        Destroy(gameObject);
    }
}