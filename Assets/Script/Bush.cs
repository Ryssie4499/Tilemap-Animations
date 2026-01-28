using UnityEngine;

public class Bush : MonoBehaviour
{
    [SerializeField] int maxHealth;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
}
