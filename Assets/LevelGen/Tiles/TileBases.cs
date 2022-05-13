using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

[CreateAssetMenu(fileName = "Tile", menuName = "AK/TileBases")]
public class TileBases : TileBase
{
    public Sprite sprite;
    public TileBase tilebase;
    public Tile_Enum TilesStruct;
}
