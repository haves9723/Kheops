using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
=======
using TMPro;

public class Enemy : MonoBehaviour
{
    //text money
    
    private static readonly int _MONEY_VALUE = 33;

    //speed enemy
    public float speed;

    public float hitPoints;
    public float maxHitPoints = 30;
    //public HealthbarBehaviour healthbar;


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


    void Awake()
    {
        enemies.Add(this);
        name = "Enemy " + enemies.Count;
    }

    // Start is called before the first frame update
    void Start()
    {
        //healthbar.SetHealth(hitPoints, maxHitPoints);
        _waypoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        transform.position =
            Vector2.MoveTowards(transform.position,
                _waypoints.waypoints[_waypointIndex].position,
                speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _waypoints.waypoints[_waypointIndex].position) < 0.1f)
        {
            _waypointIndex++;
            TakeHit(1);
        }
    }

    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        //healthbar.SetHealth(hitPoints, maxHitPoints);

        if (hitPoints <= 0)
        {
            enemies.Remove(this);
            Destroy(gameObject);
        }
>>>>>>> Stashed changes
    }
}