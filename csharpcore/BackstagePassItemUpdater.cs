using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class BackstagePassItemUpdater : BaseItemUpdater
    {
        public static new BackstagePassItemUpdater Instance
        {
            get => _backstagePassItemUpdater;
        }
        private static BackstagePassItemUpdater _backstagePassItemUpdater = new BackstagePassItemUpdater();

        protected override int getQualityModifier()
        {
            return 1;
        }

        protected override int getCurrentModifier(Item item)
        {
            if (item.SellIn >= 10)
                return 1;
            if (item.SellIn >= 5)
                return 2;
            return 3;
        }

        public override void Update(Item item)
        {
            base.Update(item);
            if (item.SellIn < 0)
                item.Quality = 0;
        }
    }
}
