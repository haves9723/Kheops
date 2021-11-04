using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy _enemy;
    private int _hitAmount;

    public void Setup(Enemy enemy, int hitAmount)
    {
        _enemy = enemy;
        _hitAmount = hitAmount;
    }

    private void Update()
    {
        if (_enemy != null)
        {
            Debug.Log(_enemy);
            Vector3 targetPosition = _enemy.transform.position;
            Vector3 moveDir = (targetPosition - transform.position).normalized;

            float moveSpeed = 10f;

            transform.position += moveDir * moveSpeed * Time.deltaTime;

            float destroySelDistance = 1f;

            if (Vector3.Distance(transform.position, targetPosition) < destroySelDistance)
            {
                Destroy(gameObject);
                _enemy.TakeHit(_hitAmount);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}