using System;
using UnityEngine;

public enum Tile_Enum
{
    Empty = 0,
    Ground = 1,
    Stone = 2,
    Hell = 666,
}

[Serializable]
public struct TileGenerator
{
    public Tile_Enum tile;
    [Range(0, 100)]
    public int fillPercentage;
    [Range(1, 3)]
    public int range;
    [Range(0, 10)]
    public int smoothing;
    [Range(0, 26)]
    public int CaveCheck;
    [Range(0, 10)]
    public int CaveBleed;

}