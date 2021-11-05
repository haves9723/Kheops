using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform prefabProjectile;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float speed;
    [SerializeField] private float interval;
    private bool _canshoot;
    [SerializeField] private float maxRange;


    private void Start()
    {
        StartCoroutine(shooting());
    }

    private void Upgrade()
    {
    }

    private Enemy GetClosestEnemy()
    {
        return Enemy.GetClosestEnemy(transform.position, maxRange);
    }

    private IEnumerator shooting()
    {
        while (true)
        {
            fire();
            yield return new WaitForSeconds(interval);
        }
    }

    public void fire()
    {
        if (GetClosestEnemy() != null)
        {
            Transform projectileTransform = Instantiate(prefabProjectile, spawnPoint.position, Quaternion.identity);
            Projectile projectile = projectileTransform.GetComponent<Projectile>();
            projectile.Setup(Enemy.GetClosestEnemy(spawnPoint.position, 40f), 1);
        }
    }
}