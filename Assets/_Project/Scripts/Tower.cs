using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform prefabProjectile;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float speed;
    [SerializeField] private float interval;
    private bool _canshoot;
    private float _maxRange;
    private float _shootTimerMax;
    private float _shootTimer;

    private void Awake()
    {
        _maxRange = 40f;
        _shootTimerMax = 1f;
    }

    private void Start()
    {
        StartCoroutine(shooting());
    }

    private void Update()
    {
        fire();
    }

    private void Upgrade()
    {
    }

    private Enemy GetClosestEnemy()
    {
        return Enemy.GetClosestEnemy(transform.position, _maxRange);
    }

    private IEnumerator shooting()
    {
        while (true)
        {
            _canshoot = true;
            yield return null;
            _canshoot = false;
            yield return new WaitForSeconds(interval);
        }
    }

    public void fire()
    {
        if (_canshoot && GetClosestEnemy() != null)
        {
            Transform projectileTransform = Instantiate(prefabProjectile, spawnPoint.position, Quaternion.identity);
            Projectile projectile = projectileTransform.GetComponent<Projectile>();
            projectile.Setup(Enemy.GetClosestEnemy(spawnPoint.position, 40f), 1);
        }
    }
}