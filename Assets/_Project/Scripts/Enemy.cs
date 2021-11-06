using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //speed enemy
    [SerializeField] private float speed;

    [SerializeField] private float hitPoints;
    [SerializeField] private float maxHitPoints = 30;
    [SerializeField] private HealthbarBehaviour healthBar;
    [SerializeField] private int enemyValue;

    private SpriteRenderer _sprite;

    public static List<Enemy> enemies = new List<Enemy>();

    //all Waypoints
    private Waypoints _waypoints;


    private int _waypointIndex;

    public void setEnemyValue(int value)
    {
        enemyValue = value;
    }

    public int getEnemyValue()
    {
        return enemyValue;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemies.Remove(this);
        Destroy(gameObject);
    }

    public Waypoints GetWayponts()
    {
        return _waypoints;
    }

    public void SetWayponts(Waypoints waypoints)
    {
        _waypoints = waypoints;
    }


    public static Enemy GetClosestEnemy(Vector3 position, float maxRange)
    {
        Enemy closest = null;
        foreach (Enemy enemy in enemies)
        {
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

        //StartCoroutine(ChangeVisibility());
    }

    public void TakeHit(float damage)
    {
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);
        if (hitPoints <= 0)
        {
            enemies.Remove(this);
            Destroy(gameObject);
            GameManager.instance.setCoins(GameManager.instance.getCoins() + enemyValue);
        }
    }

    /*private IEnumerator ChangeVisibility()
    {
        if (_sprite.color.a == 0f)
        {
            _sprite.color = new Color(1f, 1f, 1f, 5f);
        }
        else
        {
            _sprite.color = new Color(1f, 1f, 1f, 0f);
        }

        yield return new WaitForSeconds(Random.Range(0, 2f));
    }*/
}