using GildedTros.App;

public class SmellyItemProcessor : ItemProcessor
{
    public SmellyItemProcessor(Item item) : base(item) {}

    protected override void UpdateQuality() => DecreaseQuality(2);

    protected override void HandleExpired() => DecreaseQuality(2);
}