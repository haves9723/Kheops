using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int initHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthbarBehaviour healthBar;

    private void OnEnable()
    {
        currentHealth = initHealth;
    }

    public void Start()
    {
        healthBar.SetHealth(currentHealth, initHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth, initHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    /*private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth, initHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }*/

    /*public void Die()
    {
        Destroy(this);
    }*/
}


