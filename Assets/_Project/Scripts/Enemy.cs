using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    //speed enemy
    public float speed;

    public float hitPoints;
    public float maxHitPoints = 30;
    public HealthbarBehaviour healthBar;


    public static List<Enemy> enemies = new List<Enemy>();

    //all Waypoints
    private Waypoints _waypoints;

    private int _waypointIndex;


    public static Enemy GetClosestEnemy(Vector3 position, float maxRange)
    {
        Enemy closest = null;
        foreach (Enemy enemy in enemies)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    void Awake()
    {
        enemies.Add(this);
        name = "Enemy " + enemies.Count;
    }

    // Start is called before the first frame update
    void Start()
    {
        _waypoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
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
            if (_waypoints.waypoints.Length == 3)
            {
                Destroy(gameObject);
            }
            _waypointIndex++;
            TakeHit(1);
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