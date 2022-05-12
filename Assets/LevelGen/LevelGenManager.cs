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
    [SerializeField] TileGenerator[] TileGenerators;

    [Header("Tiles")]
    [SerializeField] TileBase groundTile;
    [SerializeField] TileBase stoneTile;
    [SerializeField] TileBase hellTile;
    [SerializeField] TileBase EmptyTile;
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
        this.map = GenerateMap(this.width, this.height + groundHeight + hellHeight, false);
        int[,] prefillmap = new int[,] { { } };
        prefillmap = (int[,])this.map.Clone();
        int[,] tmpMap = new int[,] { { } };
        tmpMap = (int[,])this.map.Clone();
        for (int i = 0; i < TileGenerators.Length; i++)
        {
            tmpMap = TerrainGenerater(prefillmap, TileGenerators[i]);
            tmpMap = SmoothOutcaves(tmpMap, TileGenerators[i].smoothing, (int)TileGenerators[i].tile, (int)Tile_Enum.Ground, TileGenerators[i].CaveCheck, TileGenerators[i].CaveBleed, TileGenerators[i].range);
            for (int x = 0; x < tmpMap.GetLength(0); x++)
            {
                for (int y = 0; y < tmpMap.GetLength(1); y++)
                {
                    if ((tmpMap[x, y] == (int)TileGenerators[i].tile) && this.map[x, y] == (int)Tile_Enum.Ground)
                    {
                        this.map.SetValue(tmpMap.GetValue(x, y), x, y);
                    }else if (tmpMap[x,y] == 999)
                    {
                        this.map.SetValue(0,x,y);
                    }
                }
            }
        }
        RenderBaseMap(this.map, this.BaseTileMap);
    }

    private int[,] GenerateMap(int width, int height, bool empty)
    {
        this.map = new int[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                this.map.SetValue(empty ? 0 : 1, i, j);
            }
        }
        return this.map;
    }
    public int[,] TerrainGenerater(int[,] _map, TileGenerator tilegen)
    {
        int perlinHeight;
        int j;
        System.Random rand = new System.Random(seed.GetHashCode());
        for (int i = 0; i < width; i++)
        {
            perlinHeight = hellHeight + groundHeight + Mathf.RoundToInt(Mathf.PerlinNoise(i / smoothness, seed) * height);
            for (j = 0; j <= hellHeight - 1; j++)
            {
                _map[i, j] = 666;
            }
            for (j = hellHeight; j < perlinHeight; j++)
            {
                int caveValue = (rand.Next(0, 100) < tilegen.fillPercentage) ? (int)tilegen.tile : (int)Tile_Enum.Ground;
                _map[i, j] = caveValue;
            }
            for (j = perlinHeight; j < _map.GetLength(1); j++)
            {
                _map.SetValue(999, i, j);
            }
        }
        return _map;
    }

    public int[,] SmoothOutcaves(int[,] _map, int caveSmoothness, int TileX, int TileY, int caveCheck, int CaveBleed, int range)
    {
        int erg = 0;
        if (caveSmoothness == 0) return _map;
        else
        {
            for (int a = 0; a < caveSmoothness; a++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    for (int y = 0; y < _map.GetLength(1); y++)
                    {
                        if (_map[x, y] != 0 && _map[x, y] != 666 && _map[x, y] != 999)
                        {
                            erg = GetMooreSurroundingTiles(_map, x, y, TileX, range);
                            if (erg > caveCheck)
                            {
                                _map.SetValue(TileX, x, y);
                            }
                            else
                            {
                                _map.SetValue(TileY, x, y);
                            }
                        }
                    }
                }
            }
        }
        for (int x = 0; x < _map.GetLength(0); x++)
        {
            for (int y = 0; y < _map.GetLength(1); y++)
            {
                erg = GetMooreSurroundingTiles(_map, x, y, TileX, range);
                if (erg < CaveBleed)
                {
                    SmoothoutSurrounding(_map, x, y);
                }
            }
        }
        return _map;
    }

    private int GetMooreSurroundingTiles(int[,] _map, int x, int y, int Tile, int range)
    {
        int erg = 0;
        for (int i = x - range; i <= x + range; i++)
        {
            for (int j = y - range; j <= y + range; j++)
            {
                if (x > range && x < _map.GetLength(0) - range && y > range && y < _map.GetLength(1) - range)
                {
                    if (_map[i, j] == Tile)
                    {
                        erg++;
                    }
                }
            }
        }

        return erg;
    }
    private void SmoothoutSurrounding(int[,] _map, int x, int y)
    {
        int range = 1;
        for (int i = x - range; i <= x + range; i++)
        {
            for (int j = y - range; j <= y + range; j++)
            {
                if (x > range && x < _map.GetLength(0) - range && y > range && y < _map.GetLength(1) - range)
                {
                    if (_map[i, j] != 1 && _map[i,j] != 999)
                    {
                        _map.SetValue(1, i, j);
                    }
                }
            }
        }
    }

    public void RenderBaseMap(int[,] map, Tilemap BaseMap)
    {
        // Vector3Int erg = new Vector3Int(0, 0, 0);
        for (int i = 0; i < this.map.GetLength(0); i++)
        {
            for (int j = 0; j < this.map.GetLength(1); j++)
            {

                if (this.map[i, j] == (int)Tile_Enum.Empty)
                {
                    BaseMap.SetTile(new Vector3Int(i, j, 0), EmptyTile);
                    // erg.x++;
                }else
                if (this.map[i, j] == (int)Tile_Enum.Ground)
                {
                    BaseMap.SetTile(new Vector3Int(i, j, 0), groundTile);
                    // erg.y++;
                }else
                if (this.map[i, j] == (int)Tile_Enum.Stone)
                {
                    // Debug.Log("stone");
                    BaseMap.SetTile(new Vector3Int(i, j, 0), stoneTile);
                    // erg.z++;
                }else
                if (this.map[i, j] == 666)
                {
                    BaseMap.SetTile(new Vector3Int(i, j, 0), hellTile);
                }
            }
        }
        // Debug.Log(erg);
    }
}
