using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public TilemapCollider2D mapcollider;
    public Tilemap tilemap;
    public LevelGenManager levelGenManager;

    public static Map instance;


    private void Awake() {
        instance = this;
    }

    public TilemapCollider2D GetmapCollider(){
        return this.mapcollider;
    }
}
