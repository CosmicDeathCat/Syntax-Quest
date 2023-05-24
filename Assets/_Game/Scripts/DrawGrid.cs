using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DrawGrid : MonoBehaviour
{
    [SerializeField] private GameObject gridTilePrefab;
    [SerializeField] private Vector2 offset;
    private Tilemap tileMap;

    private void Awake()
    {
        if (tileMap == null)
        {
            tileMap = GetComponent<Tilemap>();
        }
    }

    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < tileMap.size.x; x++)
        {
            for (int y = 0; y < tileMap.size.y; y++)
            {
                var spawnPosition = new Vector3(x + offset.x, y + offset.y);
                var spawnedTile = Instantiate(gridTilePrefab, spawnPosition, quaternion.identity, tileMap.transform);
                spawnedTile.name = $"Tile ({x},{y})";
            }
        }
    }
}
