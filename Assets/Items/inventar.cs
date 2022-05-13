using UnityEngine;
using UnityEngine.Tilemaps;
using System;

[Serializable]
public class inventar {
    public Item[] items;
    public inventarScreen invScreen;
    int maxItemCount;

    public void InitInventar(int Count, inventarScreen inventarScreen)
    {
        items = new Item[Count];
        invScreen = inventarScreen;
        invScreen.ReadImages();
    }

    public void SetmaxItemCount(int max)
    {
        maxItemCount = max;
    }

    public void AddItem(TileBases tile)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] == null)
            {
                items[i] = new Item();
                items[i].CreateNewItem(tile,1,99);
                invScreen.Images[i].sprite = tile.sprite;
                return;
            }
            if(items[i].tileBases == tile)
            {
                items[i].count++;
                return;
            }
        }
    }
}