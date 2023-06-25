using DLS.Game.Scripts.PlayerPrefsPlus;
using PlayerPrefsPlus;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace DLS.Game.Scripts.Utility
{
    public class DrawGrid : MonoBehaviour
    {
        [field: SerializeField] private GameObject GridTilePrefab { get; set; }
        [field: SerializeField] private Vector2 Offset { get; set; }
        private Tilemap tileMap;

        private void OnEnable()
        {
            PPPlus.OnPrefChanged += OnPrefChanged;
        }

        private void OnDisable()
        {
            PPPlus.OnPrefChanged -= OnPrefChanged;
        }

        private void Awake()
        {
            if (tileMap == null)
            {
                tileMap = GetComponent<Tilemap>();
            }
        }

        private void Start()
        {
            var gridOverlay = PPPlus.GetBool(Prefs.EnableGridOverlay);
            if (gridOverlay)
            {
                GenerateGrid();
            }
        }

        public void GenerateGrid()
        {
            for (int x = 0; x < tileMap.size.x; x++)
            {
                for (int y = 0; y < tileMap.size.y; y++)
                {
                    var spawnPosition = new Vector3(x + Offset.x, y + Offset.y);
                    var spawnedTile = Instantiate(GridTilePrefab, spawnPosition, quaternion.identity,
                        tileMap.transform);
                    spawnedTile.name = $"Tile ({x},{y})";
                }
            }
        }

        public void DestroyGrid()
        {
            if (tileMap.transform.childCount > 0)
            {
                for (int i = tileMap.transform.childCount - 1; i >= 0; i--)
                {
                    var child = tileMap.transform.GetChild(i);
                    if (child.name.Contains("Tile"))
                    {
                        Destroy(child.gameObject);
                    }
                }
            }
        }

        private void OnPrefChanged(string key, object obj)
        {
            if (key.Equals(Prefs.EnableGridOverlay))
            {
                if ((bool)obj)
                {
                    GenerateGrid();
                }
                else
                {
                    DestroyGrid();
                }
            }
        }
    }
}