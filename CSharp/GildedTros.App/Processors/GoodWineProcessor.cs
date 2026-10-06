using GildedTros.App;

public class GoodWineProcessor : ItemProcessor
{
    public GoodWineProcessor(Item item) : base(item) {}

    protected override void UpdateQuality() => IncreaseQuality();
    protected override void HandleExpired() => IncreaseQuality();
}