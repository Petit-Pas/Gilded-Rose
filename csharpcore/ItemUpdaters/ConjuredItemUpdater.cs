using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore.ItemUpdaters
{
    public class ConjuredItemUpdater : BaseItemUpdater
    {
        public static new ConjuredItemUpdater Instance
        {
            get => _conjuredItemUpdater;
        }
        private static ConjuredItemUpdater _conjuredItemUpdater = new ConjuredItemUpdater();

        protected override int getQualityModifier()
        {
            return -2;
        }
    }
}
