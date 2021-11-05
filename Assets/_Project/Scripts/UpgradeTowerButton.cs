using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeTowerButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        Tower tower = gameObject.transform.parent.GetComponent<Tower>();
        if (tower.upgradeLevel != tower.sprites.Length)
        {
            tower.Upgrade(tower.sprites[tower.upgradeLevel], 0.3f, 40f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}