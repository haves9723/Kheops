using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Vector3 _projectileShootFromPosition;
    private float _maxRange;
    private float _shootTimerMax;
    private float _shootTimer;


    private void Awake()
    {
        _projectileShootFromPosition = transform.Find("ProjectileShootFromPosition").position;
        _maxRange = 40f;
        _shootTimerMax = 1f;
    }

    private void Update()
    {
        _shootTimer -= Time.deltaTime;

        if (_shootTimer <= 0f)
        {
            _shootTimer = _shootTimerMax;


            Enemy enemy = GetClosestEnemy();
            if (enemy != null)
            {
                Projectile.Create(_projectileShootFromPosition, enemy, 1);
            }
        }
    }

    private Enemy GetClosestEnemy()
    {
        return Enemy.GetClosestEnemy(transform.position, _maxRange);
    }
    
}