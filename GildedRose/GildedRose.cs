using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        foreach (var item in Items)
        {
            switch (GetItemType(item))
            {
                case ItemType.Common:
                    UpdateCommonItem(item);
                    break;
                case ItemType.AgedBrie:
                    UpdateAgedBrieItem(item);
                    break;
                case ItemType.Sulfuras:
                    continue;
                case ItemType.BackstagePasses:
                    UpdateBackstagePassesItem(item);
                    break;
            }

            if (item.Quality < 0) item.Quality = 0;
            if (item.Quality > 50) item.Quality = 50;
        }
    }

    private void UpdateCommonItem(Item item)
    {
        item.SellIn--;
        item.Quality--;
        if (item.SellIn < 0) item.Quality--;
    }

    private void UpdateAgedBrieItem(Item item)
    {
        item.SellIn--;
        item.Quality++;
        if (item.SellIn < 0) item.Quality++;
    }

    private void UpdateBackstagePassesItem(Item item)
    {
        if (item.SellIn > 10) item.Quality++;
        else if (item.SellIn > 5) item.Quality += 2;
        else if (item.SellIn > 0) item.Quality += 3;
        else item.Quality = 0;

        item.SellIn--;
    }

    private ItemType GetItemType(Item item)
    {
        var itemName = item.Name;
        if (itemName.StartsWith("Conjured "))
            itemName = itemName.Substring(0, 9);

        if (itemName.StartsWith("Sulfuras")) return ItemType.Sulfuras;
        if (itemName.StartsWith("Backstage passes")) return ItemType.BackstagePasses;
        if (itemName == "Aged Brie") return ItemType.AgedBrie;

        return ItemType.Common;
    }
}

internal enum ItemType
{
    Common,
    AgedBrie,
    BackstagePasses,
    Sulfuras
}