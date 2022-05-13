using UnityEngine;
using UnityEngine.Tilemaps;

public class Item {
    public TileBases tileBases;
    public int count;
    public int maxCount;

    public void CreateNewItem(TileBases tileBases, int count, int maxCount)
    {
        this.tileBases = tileBases;
        this.count = count;
        this.maxCount = maxCount;
    }
}