using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class BaseItemUpdater
    {
        public static BaseItemUpdater Instance
        {
            get => _baseItemUpdater;
        }
        static private BaseItemUpdater _baseItemUpdater = new BaseItemUpdater();

        protected virtual int getMaxValue()
        {
            return 50;
        }

        protected virtual int getMinValue()
        {
            return 0;
        }

        protected virtual int getQualityModifier()
        {
            return -1;
        }

        protected virtual int getCurrentModifier(Item item)
        {
            if (item.SellIn >= 0)
                return 1;
            return 2;
        }

        public virtual void Update(Item item)
        {
            item.SellIn -= 1;

            item.Quality += getQualityModifier() * getCurrentModifier(item);

            if (item.Quality > getMaxValue())
                item.Quality = getMaxValue();
            else if (item.Quality < getMinValue())
                item.Quality = getMinValue();
        }
    }
}
