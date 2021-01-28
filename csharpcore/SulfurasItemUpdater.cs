using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class SulfurasItemUpdater : BaseItemUpdater
    {
        public static new SulfurasItemUpdater Instance
        {
            get => _sulfurasItemUpdater;
        }
        private static SulfurasItemUpdater _sulfurasItemUpdater = new SulfurasItemUpdater();

        protected override int getQualityModifier()
        {
            return 0;
        }

        protected override int getSellInModifier()
        {
            return 0;
        }

        protected override int getMaxValue()
        {
            return 80;
        }
    }
}
