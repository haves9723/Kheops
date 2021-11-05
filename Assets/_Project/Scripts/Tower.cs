using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform prefabProjectile;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float speed;
    [SerializeField] private float interval;
    [SerializeField] private float maxRange;
    [SerializeField] public Sprite[] sprites;
    public int upgradeLevel;
    

    private void Start()
    {
        upgradeLevel = 0;
        StartCoroutine(Shooting());
    }

    public void Upgrade(Sprite newSprite, float interval, float maxRange)
    {
        if (upgradeLevel < sprites.Length)
        {
            upgradeLevel++;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        this.interval = interval;
        this.maxRange = maxRange;
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
}