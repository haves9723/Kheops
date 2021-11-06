using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var body = other.rigidbody;
        if (body)
            DealDamage(body.gameObject);
        else
            DealDamage(other.gameObject);
    }


    void DealDamage(GameObject obj)
    {
        var dam = obj.GetComponent<IDamageable>();
        dam?.TakeDamage(damage);
    }
}
