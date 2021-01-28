using csharpcore;
using System;
using System.Collections.Generic;
using Xunit;

namespace csharpcoreXUnitTests
{
    public class NormalItemsTest
    {
        [Fact]
        public void Test()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 3, Quality = 20},
            };

            GildedRose gildedRose = new GildedRose(items);

            // normal update
            gildedRose.UpdateQuality();
            Assert.Equal(2, items[0].SellIn);
            Assert.Equal(19, items[0].Quality);

            // reaches 0
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(17, items[0].Quality);

            // update after sell date has passed
            gildedRose.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(15, items[0].Quality);

            // updated after Quality has reached 0
            for (int i = 0; i != 10; i += 1)
                gildedRose.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }
    }
}
