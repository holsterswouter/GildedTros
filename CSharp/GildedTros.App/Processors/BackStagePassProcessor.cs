using GildedTros.App;

public class BackstagePassProcessor : ItemProcessor
{
    public BackstagePassProcessor(Item item) : base(item) {}

    protected override void UpdateQuality()
    {
        IncreaseQuality(Item.SellIn <= 5 ? 3 : Item.SellIn <= 10 ? 2 : 1);
    }

    protected override void HandleExpired()
    {
       Item.Quality = 0;
    }
}