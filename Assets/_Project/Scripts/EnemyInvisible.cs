using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyInvisible : MonoBehaviour
{
    //speed enemy
    public float speed;

    public float hitPoints;
    public float maxHitPoints = 30;
    public HealthbarBehaviour healthBar;


    public static List<EnemyInvisible> enemies = new List<EnemyInvisible>();

    //all Waypoints
    private Waypoints _waypoints;

    private int _waypointIndex;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }


    public static EnemyInvisible GetClosestEnemy(Vector3 position, float maxRange)
    {
        EnemyInvisible closest = null;
        foreach (EnemyInvisible enemy in enemies)
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
        _waypoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        //gameObject.GetComponent<Renderer>().enabled = false;
        healthBar.SetHealth(hitPoints, maxHitPoints);
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        

        transform.position = 
            Vector2.MoveTowards(transform.position,
                _waypoints.waypoints[_waypointIndex].position,
                speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _waypoints.waypoints[_waypointIndex].position) < 0.1f)
        {
            sprite.color = new Color(1f, 1f, 1f, .5f);
            //gameObject.GetComponent<Renderer>().enabled = true;
            _waypointIndex++;
            speed = 3;
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
