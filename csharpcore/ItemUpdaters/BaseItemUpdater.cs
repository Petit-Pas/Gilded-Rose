using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore.ItemUpdaters
{
    public class BaseItemUpdater
    {
        public static BaseItemUpdater Instance
        {
            get => _baseItemUpdater;
        }
        private static BaseItemUpdater _baseItemUpdater = new BaseItemUpdater();

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

        /// <summary>
        ///     modifier to apply to getQualityModifier() depending on the period (example: after SellIn)
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual int getPeriodModifier(Item item)
        {
            if (item.SellIn >= 0)
                return 1;
            return 2;
        }

        protected virtual int getSellInModifier()
        {
            return -1;
        }

        public virtual void Update(Item item)
        {
            item.SellIn += getSellInModifier();

            item.Quality += getQualityModifier() * getPeriodModifier(item);

            if (item.Quality > getMaxValue())
                item.Quality = getMaxValue();
            else if (item.Quality < getMinValue())
                item.Quality = getMinValue();
        }
    }
}
