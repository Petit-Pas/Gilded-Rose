using csharpcore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace csharpcoreXUnitTests
{
    public class SulfurasTest
    {
        [Fact]
        public void Test()
        {
            IList<Item> items = new List<Item>{
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80},
            };

            GildedRose gildedRose = new GildedRose(items);

            // normal update
            gildedRose.UpdateQuality();
            Assert.Equal(2, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }
    }
}
