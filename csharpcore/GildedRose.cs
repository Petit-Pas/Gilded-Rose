using csharpcore.ItemUpdaters;
using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private enum ItemType {
            Normal,
            AgedBrie,
            Sulfura,
            BackstagePass,
            ConjuredItem,
        }

        IList<(ItemType Type, Item Item)> Items;
        
        /// <summary>
        ///     Saving the items as tuples with the ItemType in order to gain CPU usage and time
        /// </summary>
        /// <param name="items"></param>
        public GildedRose(IList<Item> items)
        {
            Items = new List<(ItemType, Item)>();

            // Conjured items are still missing
            foreach (Item item in items)
            {
                if (item.Name.Equals("Aged Brie"))
                    Items.Add((ItemType.AgedBrie, item));
                // who knows if we can have Sulfuras that are not "Hand of Ragnaros"
                else if (item.Name.Contains("Sulfura"))
                    Items.Add((ItemType.Sulfura, item));
                // who knows if we can have backstage passes to other concerts
                else if (item.Name.StartsWith("Backstage passes to"))
                    Items.Add((ItemType.BackstagePass, item));
                else if (item.Name.Contains("Conjured"))
                    Items.Add((ItemType.ConjuredItem, item));
                else
                    Items.Add((ItemType.Normal, item));
            }
        }

        public void UpdateQuality()
        {
            foreach ((ItemType Type, Item Item) data in Items)
            {
                switch (data.Type)
                {
                    case ItemType.Normal:
                        BaseItemUpdater.Instance.Update(data.Item);
                        break;
                    case ItemType.AgedBrie:
                        AgedBrieItemUpdater.Instance.Update(data.Item);
                        break;
                    case ItemType.Sulfura:
                        SulfurasItemUpdater.Instance.Update(data.Item);
                        break;
                    case ItemType.BackstagePass:
                        BackstagePassItemUpdater.Instance.Update(data.Item);
                        break;
                    case ItemType.ConjuredItem:
                        ConjuredItemUpdater.Instance.Update(data.Item);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
