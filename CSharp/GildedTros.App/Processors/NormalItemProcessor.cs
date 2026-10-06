using GildedTros.App;

public class NormalItemProcessor : ItemProcessor
{
    public NormalItemProcessor(Item item) : base(item){}

    protected override void UpdateQuality() => DecreaseQuality();
    protected override void HandleExpired() => DecreaseQuality();
}