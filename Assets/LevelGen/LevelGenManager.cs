using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenManager : MonoBehaviour
{
    [Header("height Settings")]
    [SerializeField] int groundHeight = 5;
    [SerializeField] int hellHeight = 2;
    [SerializeField] int width, height;
    [SerializeField] float smoothness;
    [SerializeField] float seed;
    [Range(0, 1)] [SerializeField] float caveMod;
    [Range(0, 10)] [SerializeField] int caveModSmoothness = 4;
    [Range(0, 100)] [SerializeField] int fillPercent;

    [Header("Tiles")]
    [SerializeField] TileBase groundTile;
    [SerializeField] TileBase stoneTile;
    [SerializeField] TileBase hellTile;
    [SerializeField] Tilemap BaseTileMap;
    int[,] map;
    public int state = 0;

    void Start()
    {
        map = new int[width, height];
        Generate();
    }

    private void Generate()
    {
        BaseTileMap.ClearAllTiles();
        this.map = GenerateMap(this.width, this.height + groundHeight + hellHeight, true);
        this.map = TerrainGenerater(this.map);
        this.map = SmoothOutcaves(this.map, caveModSmoothness);
        RenderBaseMap(this.map, this.BaseTileMap, this.groundTile);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Generate();
        }
    }

    private int[,] GenerateMap(int width, int height, bool empty)
    {
        map = new int[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i, j] = empty ? 0 : 1;
            }
        }
        return map;
    }
    public int[,] TerrainGenerater(int[,] map)
    {
        int perlinHeight;
        System.Random rand = new System.Random(seed.GetHashCode());
        for (int i = 0; i < width; i++)
        {
            perlinHeight = hellHeight + groundHeight + Mathf.RoundToInt(Mathf.PerlinNoise(i / smoothness, seed) * height);
            int j;
            for (j = 0; j <= hellHeight - 1; j++)
            {
                map[i, j] = 666;
            }
            for (j = hellHeight; j < perlinHeight; j++)
            {
                //int caveValue = Mathf.RoundToInt(Mathf.PerlinNoise((i * caveMod) + seed, (j * caveMod) + seed));
                int caveValue = (rand.Next(0, 100) < fillPercent) ? 1 : 0;
                map[i, j] = caveValue + 1;
            }
        }
        return map;
    }
    public int[,] SmoothOutcaves(int[,] map, int caveSmoothness)
    {
        if (caveSmoothness == 0) return this.map;
        else
            for (int a = 0; a < caveSmoothness; a++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    for (int y = 0; y < map.GetLength(1); y++)
                    {
                        if (map[x, y] != 0 && map[x, y] != 666)
                        {
                            int erg = GetMooreSurroundingTiles(map, x, y);
                            if (x > 0 && x + 1 < map.GetUpperBound(0))
                            {
                                if (y > 0 && y + 1 < map.GetUpperBound(1))
                                {
                                    map[x, y] = erg > 4 ? 2 : 1;
                                }
                            }
                        }
                    }
                }
                this.map = map;
            }
        return map;
    }

    private static int GetMooreSurroundingTiles(int[,] map, int x, int y, int erg = 0)
    {
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (x > 0 && x < map.GetUpperBound(0) && y > 0 && y < map.GetUpperBound(1))
                {
                    if (x != i || y != j)
                    {
                        if(map[i,j] == 2){
                            erg ++;
                        }
                    }
                }
            }
        }

        return erg;
    }

    public void RenderBaseMap(int[,] map, Tilemap BaseMap, TileBase groundTiles)
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == 1)
                {
                    BaseMap.SetTile(new Vector3Int(i, j, 0), groundTile);
                }
                if (map[i, j] == 2)
                {
                    BaseMap.SetTile(new Vector3Int(i, j, 0), stoneTile);
                }
                else
                if (map[i, j] == 666)
                {
                    BaseMap.SetTile(new Vector3Int(i, j, 0), hellTile);
                }
            }
        }
    }
}
