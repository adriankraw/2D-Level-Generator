using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Item {
    private string name;
    public TileBases tileBases;
    private Sprite sprite;
    public int count;
    public int maxCount;
    public ItemEnums itemEnums{ get; private set;}


    private int Dmg;
    private float AttackSpeed;

    public void CreateNewItem(TileBases tileBases, int count, int maxCount, ItemEnums itemEnums)
    {
        this.tileBases = tileBases;
        this.sprite = tileBases.sprite;
        this.count = count;
        this.maxCount = maxCount;
        this.itemEnums = itemEnums;
    }
    public void CreateNewItem(string Name, Sprite sprite, int Dmg, float AttackSpeed, ItemEnums itemEnums)
    {
        this.name = Name;
        this.sprite = sprite;
        this.Dmg = Dmg;
        this.AttackSpeed = AttackSpeed;
        this.itemEnums = itemEnums;
    }
}