using csharpcore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace csharpcoreXUnitTests
{
    public class BackstagePassesTest
    {
        [Fact]
        public void Test()
        {
            IList<Item> items = new List<Item>{
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 10
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 30
                },
            };

            GildedRose gildedRose = new GildedRose(items);

            // normal update
            gildedRose.UpdateQuality();
            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(11, items[0].Quality);

            // reaches 10 days left
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            Assert.Equal(10, items[0].SellIn);
            Assert.Equal(15, items[0].Quality);

            // reaches 5 days left
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            Assert.Equal(5, items[0].SellIn);
            Assert.Equal(25, items[0].Quality);

            // reached the concert day
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(40, items[0].Quality);
            Assert.Equal(0, items[1].SellIn);
            Assert.Equal(50, items[1].Quality);

            // after the concert
            gildedRose.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
            Assert.Equal(-1, items[1].SellIn);
            Assert.Equal(0, items[1].Quality);
        }
    }
}
