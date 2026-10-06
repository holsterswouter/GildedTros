using GildedTros.App;

public class LegendaryItemProcessor : ItemProcessor
{
    public LegendaryItemProcessor(Item item) : base(item){}

    public override void Update() { }
    protected override void UpdateQuality() { }
    protected override void HandleExpired() { }
}