using UnityEngine;
using UnityEngine.Tilemaps;
using System;

[Serializable]
public class inventar {
    public Item[] items;
    public inventarScreen invScreen;
    int maxItemCount;
    public int lastSelectedItem;
    public Sprite WeaponSprite;
    public Sprite PickAxeSprite;

    public void InitInventar(int Count, inventarScreen inventarScreen)
    {
        items = new Item[Count];
        invScreen = inventarScreen;
        invScreen.ReadImages();
        lastSelectedItem = -1;

        AddItem("Annoying StartWeapon", 99, 0.5F, ItemEnums.Weapon);
        AddItem("Start Pickaxe", 1, 0.5F, ItemEnums.Pickaxe);
        SetSelectedItem(0);
    }
    public void SetSelectedItem(int index)
    {
        if (index != lastSelectedItem)
        {
            if (lastSelectedItem != -1)
            {
                invScreen.DeSelect(lastSelectedItem);
            }
            lastSelectedItem = index;
            invScreen.Select(lastSelectedItem);
        }
    }
    public int GetSelectedItem() 
    {
        return invScreen.lastImageIndex;
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
                items[i].CreateNewItem(tile,1,99,ItemEnums.Tile);
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
    public void AddItem(string Name, int Dmg, float AttackSpeed, ItemEnums itemEnums){
        switch (itemEnums)
        {
            case ItemEnums.Weapon:
                items[0] = new Item();
                items[0].CreateNewItem(Name, WeaponSprite, Dmg, AttackSpeed, itemEnums);
                invScreen.Images[0].sprite = WeaponSprite;
            break;
            case ItemEnums.Pickaxe:
                items[1] = new Item();
                items[1].CreateNewItem(Name, PickAxeSprite, Dmg, AttackSpeed, itemEnums);
                invScreen.Images[1].sprite = PickAxeSprite;
            break;
            default:
            break;
        }
    }
}