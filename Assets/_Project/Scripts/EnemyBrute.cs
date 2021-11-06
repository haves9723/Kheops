using System.Collections.Generic;
using UnityEngine;

public class EnemyBrute : MonoBehaviour
{
    
    //speed enemy
    [SerializeField] private float speed;

    [SerializeField] private float hitPoints;
    [SerializeField] private float maxHitPoints = 300;
    [SerializeField] private HealthbarBehaviour healthBar;

    public static List<EnemyBrute> enemies = new List<EnemyBrute>();
 
    //all Waypoints
    private Waypoints _waypoints;

    private int _waypointIndex;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemies.Remove(this);
        Destroy(gameObject);
    }


    public static EnemyBrute GetClosestEnemy(Vector3 position, float maxRange)
    {
        EnemyBrute closest = null;
        foreach (EnemyBrute enemy in enemies)
        {
            // if (enemy.IsDead()) continue;
            if (Vector3.Distance(position, enemy.transform.position) <= maxRange)
            {
                if (closest == null)
                {
                    closest = enemy;
                }
                else
                {
                    if (Vector3.Distance(position, enemy.transform.position) <
                        Vector3.Distance(position, closest.transform.position))
                    {
                        closest = enemy;
                    }
                }
            }
        }

        return closest;
    }


    void Awake()
    {
        enemies.Add(this);
        name = "Enemy " + enemies.Count;
    }

    // Start is called before the first frame update
    void Start()
    {
        _waypoints = FindObjectOfType<Waypoints>();
        healthBar.SetHealth(hitPoints, maxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector2.MoveTowards(transform.position,
                _waypoints.waypoints[_waypointIndex].position,
                speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _waypoints.waypoints[_waypointIndex].position) < 0.1f)
        {
            _waypointIndex++;
        }
    }

    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            enemies.Remove(this);
            Destroy(gameObject);
        }
    }

}
