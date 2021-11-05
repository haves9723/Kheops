using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    public float hitPoints;
    public float maxHitPoints = 100;
    public HealthbarBehaviour healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetHealth(hitPoints, maxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
