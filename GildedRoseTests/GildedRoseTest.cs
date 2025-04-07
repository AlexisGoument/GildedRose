using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void UpdateQuality_WithCommonItem_ShouldDecreaseQuality()
    {
        var items = new List<Item> { new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("+5 Dexterity Vest"));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(19));
    }

    [Test]
    public void UpdateQuality_WithCommonItem_ShouldNotDecreaseQualityBeyond0()
    {
        var items = new List<Item> { new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 0 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("+5 Dexterity Vest"));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }

    // [Test]
    // public void UpdateQuality_WithConjuredCommonItem_ShouldDecreaseQualityTwice()
    // {
    //     var items = new List<Item> { new() { Name = "Conjured +5 Dexterity Vest", SellIn = 10, Quality = 20 } };
    //     var app = new GildedRose(items);
    //
    //     app.UpdateQuality();
    //
    //     Assert.That(items[0].Name, Is.EqualTo("Conjured +5 Dexterity Vest"));
    //     Assert.That(items[0].SellIn, Is.EqualTo(9));
    //     Assert.That(items[0].Quality, Is.EqualTo(18));
    // }

    [Test]
    public void UpdateQuality_WithCommonItemWhenNegativeSellIn_ShouldDecreaseQualityTwice()
    {
        var items = new List<Item> { new() { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("+5 Dexterity Vest"));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(18));
    }

    [Test]
    public void UpdateQuality_WithAgedBrie_ShouldIncreaseQuality()
    {
        var items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("Aged Brie"));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(21));
    }

    [Test]
    public void UpdateQuality_WithAgedBrieWhenNegativeSellIn_ShouldIncreaseQualityTwice()
    {
        var items = new List<Item> { new() { Name = "Aged Brie", SellIn = 0, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("Aged Brie"));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
        Assert.That(items[0].Quality, Is.EqualTo(22));
    }

    [Test]
    public void UpdateQuality_WithAgedBrie_ShouldNotIncreaseQualityBeyond50()
    {
        var items = new List<Item> { new() { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("Aged Brie"));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
        Assert.That(items[0].Quality, Is.EqualTo(50));
    }

    [Test]
    public void UpdateQuality_WithSulfuras_ShouldDoNothing()
    {
        var items = new List<Item> { new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("Sulfuras, Hand of Ragnaros"));
        Assert.That(items[0].SellIn, Is.EqualTo(10));
        Assert.That(items[0].Quality, Is.EqualTo(20));
    }

    [Test]
    public void UpdateQuality_WithBackstagePassesWhenSellIs11_ShouldIncreaseQualityOnce()
    {
        var items = new List<Item>
            { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"));
        Assert.That(items[0].SellIn, Is.EqualTo(10));
        Assert.That(items[0].Quality, Is.EqualTo(21));
    }

    [TestCase(10)]
    [TestCase(9)]
    [TestCase(8)]
    [TestCase(7)]
    [TestCase(6)]
    public void UpdateQuality_WithBackstagePassesWhenSellInBetween6And10_ShouldIncreaseQualityTwice(int sellIn)
    {
        var items = new List<Item>
            { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"));
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(items[0].Quality, Is.EqualTo(22));
    }

    [TestCase(5)]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(2)]
    [TestCase(1)]
    public void UpdateQuality_WithBackstagePassesWhenSellInBetween0And5_ShouldIncreaseQualityTwice(int sellIn)
    {
        var items = new List<Item>
            { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"));
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(items[0].Quality, Is.EqualTo(23));
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void UpdateQuality_WithBackstagePassesWhenSellInIs0AndBelow_ShouldSetQualityTo0(int sellIn)
    {
        var items = new List<Item>
            { new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 20 } };
        var app = new GildedRose(items);

        app.UpdateQuality();

        Assert.That(items[0].Name, Is.EqualTo("Backstage passes to a TAFKAL80ETC concert"));
        Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        Assert.That(items[0].Quality, Is.EqualTo(0));
    }
}