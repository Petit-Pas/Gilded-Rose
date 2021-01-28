using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore
{
    public class AgedBrieItemUpdater : BaseItemUpdater
    {
        public static new AgedBrieItemUpdater Instance
        {
            get => _agedBrieItemUpdater;
        }
        private static AgedBrieItemUpdater _agedBrieItemUpdater = new AgedBrieItemUpdater();

        protected override int getQualityModifier()
        {
            return 1;
        }
    }
}
