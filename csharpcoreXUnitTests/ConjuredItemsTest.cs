using csharpcore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace csharpcoreXUnitTests
{
    public class ConjuredItemsTest
    {
        [Fact]
        public void Test()
        {
            IList<Item> items = new List<Item> {
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 16}
            };

            GildedRose gildedRose = new GildedRose(items);

            // normal update
            gildedRose.UpdateQuality();
            Assert.Equal(2, items[0].SellIn);
            Assert.Equal(14, items[0].Quality);

            // reaches sell date
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(10, items[0].Quality);

            // update after sell date has passed
            gildedRose.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(6, items[0].Quality);

            // updated after Quality has reached 0
            for (int i = 0; i != 10; i += 1)
                gildedRose.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }
    }
}
