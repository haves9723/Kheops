using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform prefabProjectile;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float interval;
    [SerializeField] private float maxRange;
    [SerializeField] public Sprite[] sprites;
    [SerializeField] private int towerCost;
    [SerializeField] public int towerLevel;


    private void Start()
    {
        towerLevel = 1;
        StartCoroutine(Shooting());
    }

    public void Upgrade()
    {
        if (towerLevel <= sprites.Length)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[towerLevel-1];
            towerLevel++;
            interval -= .5f;
            maxRange *= 2;
        }
    }

    private Enemy GetClosestEnemy()
    {
        return Enemy.GetClosestEnemy(transform.position, maxRange);
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            fire();
            yield return new WaitForSeconds(interval);
        }
    }

    private void fire()
    {
        if (GetClosestEnemy() != null)
        {
            Transform projectileTransform = Instantiate(prefabProjectile, spawnPoint.position, Quaternion.identity);
            Projectile projectile = projectileTransform.GetComponent<Projectile>();
            projectile.Setup(GetClosestEnemy(), 1);
        }
    }

    public int getTowerCost()
    {
        return towerCost;
    }
}