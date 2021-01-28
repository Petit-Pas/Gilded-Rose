using csharpcore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace csharpcoreXUnitTests
{
    public class AgedBrieTest
    {
        [Fact]
        public void Test()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            };

            GildedRose gildedRose = new GildedRose(items);

            // normal update
            gildedRose.UpdateQuality();
            Assert.Equal(1, items[0].SellIn);
            Assert.Equal(1, items[0].Quality);

            // reaches sell date
            gildedRose.UpdateQuality();
            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(2, items[0].Quality);

            // update after sell date has passed
            gildedRose.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(4, items[0].Quality);

            //update after Quality has reached 50
            for (int i = 0; i != 30; i += 1)
                gildedRose.UpdateQuality();
            Assert.Equal(50, items[0].Quality);


        }
    }
}
