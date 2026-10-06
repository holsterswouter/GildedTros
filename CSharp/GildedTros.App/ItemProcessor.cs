using System;
using GildedTros.App;

public abstract class ItemProcessor
{
    protected readonly Item Item;

    protected ItemProcessor(Item item) => Item = item;

    public virtual void Update()
    {
        UpdateQuality();
        UpdateSellIn();

        if(IsExpired())
            HandleExpired();
    }

    protected abstract void UpdateQuality();
    protected virtual void UpdateSellIn() => Item.SellIn--;
    protected bool IsExpired() => Item.SellIn < 0;
    protected abstract void HandleExpired();

    protected void IncreaseQuality(int amount = 1) => Item.Quality = Math.Min(50, Item.Quality + amount);
    protected void DecreaseQuality(int amount = 1) => Item.Quality = Math.Max(0, Item.Quality - amount);
}

public static class ItemProcessorFactory
{
    public static ItemProcessor Create(Item item)  
    {
        switch(item.Name)
        {
            case "B-DAWG Keychain":
                return new LegendaryItemProcessor(item);
            case "Good Wine":
                return new GoodWineProcessor(item);
            case "Backstage passes for Re:factor":
            case "Backstage passes for HAXX":
                return new BackstagePassProcessor(item);
            default:
                return new NormalItemProcessor(item);   
        }
    }
}