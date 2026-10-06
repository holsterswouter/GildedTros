using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        [Fact]
        public void Default()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "RandomItem", SellIn = 1, Quality = 1 }, 
                new Item { Name = "RandomItem2", SellIn = 0, Quality = 2 },
                new Item { Name = "RandomItem3", SellIn = 0, Quality = 1 }
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Multiple(
                () => Assert.Equal(0, Items[0].SellIn),
                () => Assert.Equal(0, Items[0].Quality),
                () => Assert.Equal(-1, Items[1].SellIn),
                () => Assert.Equal(0, Items[1].Quality),
                () => Assert.Equal(-1, Items[2].SellIn),
                () => Assert.Equal(0, Items[2].Quality)
            );
        }

        [Fact]
        public void GoodWine()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "Good Wine", SellIn = 1, Quality = 1 }, 
                new Item { Name = "Good Wine", SellIn = 0, Quality = 2 }, 
                new Item { Name = "Good Wine", SellIn = 0, Quality = 50 } 
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Multiple(
                () => Assert.Equal(0, Items[0].SellIn),
                () => Assert.Equal(2, Items[0].Quality),
                () => Assert.Equal(-1, Items[1].SellIn),
                () => Assert.Equal(4, Items[1].Quality),
                () => Assert.Equal(50, Items[2].Quality)
            );
        }

        [Fact]
        public void Legendary()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "B-DAWG Keychain", SellIn = 1, Quality = 80 } };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Multiple(
                () => Assert.Equal(1, Items[0].SellIn),
                () => Assert.Equal(80, Items[0].Quality)
            );
        }

        [Fact]
        public void BackstagePass()
        {
            IList<Item> Items = new List<Item> { 
                new Item { Name = "Backstage passes for Re:factor", SellIn = 11, Quality = 24 },
                new Item { Name = "Backstage passes for Re:factor", SellIn = 10, Quality = 24 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 5, Quality = 24 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 0, Quality = 24 },
                new Item { Name = "Backstage passes for HAXX", SellIn = 4, Quality = 49 }
            };
            GildedTros app = new GildedTros(Items);
            app.UpdateQuality();
            Assert.Multiple(
                () => Assert.Equal(10, Items[0].SellIn),
                () => Assert.Equal(25, Items[0].Quality),
                () => Assert.Equal(9, Items[1].SellIn),
                () => Assert.Equal(26, Items[1].Quality),
                () => Assert.Equal(4, Items[2].SellIn),
                () => Assert.Equal(27, Items[2].Quality),
                () => Assert.Equal(-1, Items[3].SellIn),
                () => Assert.Equal(0, Items[3].Quality),
                () => Assert.Equal(50, Items[4].Quality)
            );
        }
    }
}