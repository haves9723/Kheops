using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    //list of towers (prefabs) that will instantiate
    public List<GameObject> towersPrefabs;

    //Transform of spawning towers (Root Object)
    public Transform spawnTowerRoot;

    //list of towers(UI)
    public List<Image> towersUI;

    //id of tower to spawn
    private int spawnID = -1;

    //SpawnPoints Tilemap
    public Tilemap spawnTilemap;
    private Tilemap _spawnPointTowersTilemap;


    private void Start()
    {
        _spawnPointTowersTilemap = GameObject.FindWithTag("SpawnPointTowers").GetComponent<Tilemap>();
    }

    void Update()
    {
        if (CanSpawn())
        {
            DetectSpawnPoint();
        }
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
        {
            return false;
        }

        return true;
    }


    void DetectSpawnPoint()
    {
        //Detect when mouse is clicked (first touch clicked)
        if (Input.GetMouseButtonDown(0))
        {
            //get the world space at the position of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tile
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            //get the center position of the cell
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            //check if we can spawn in that cell (collider)
            if (spawnTilemap.GetColliderType(cellPosDefault) == Tile.ColliderType.Sprite)
            {
                GameObject towerObject = Instantiate(towersPrefabs[spawnID], spawnTowerRoot);
                Tower tower = towerObject.GetComponent<Tower>();
                if (GameManager.instance.getCoins() >= tower.getTowerCost())
                {
                    //Spawn the tower
                    SpawnTower(cellPosCentered, towerObject, tower);
                    //Disable the collider
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    towersUI[spawnID].color = Color.red;
                    DeselectTowers();
                }
            }
        }
    }

    void SpawnTower(Vector3 position, GameObject towerObject, Tower tower)
    {
        towerObject.transform.position = position;
        GameManager.instance.setCoins(GameManager.instance.getCoins() - tower.getTowerCost());
        DeselectTowers();
    }


    public void SelectTower(int id)
    {
        if (id == spawnID)
        {
            DeselectTowers();
        }
        else
        {
            DeselectTowers();
            //set the SpawnID 
            spawnID = id;
            //Highlight the tower
            towersUI[spawnID].color = Color.white;
            _spawnPointTowersTilemap.color = new Color(0f, 0f, 0f, .3f);
        }
    }

    public void DeselectTowers()
    {
        spawnID = -1;
        foreach (var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
            _spawnPointTowersTilemap.color = new Color(0f, 0f, 0f, 0f);
        }

        {
        }
    }
}