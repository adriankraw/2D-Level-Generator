using System;
using UnityEngine;

public enum Tile_Enum
{
    Empty = 0,
    Ground = 1,
    Stone = 2,
}

[Serializable]
public struct TileGenerator{
    public Tile_Enum tile;
    [Range(0, 1)]
    public float cavemode;
    [Range(0, 10)]
    public int smoothing;

    [Range(0,100)]
    public int fillPercentage;
}