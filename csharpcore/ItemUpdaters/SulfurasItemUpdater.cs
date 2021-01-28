using System;
using System.Collections.Generic;
using System.Text;

namespace csharpcore.ItemUpdaters
{
    public class SulfurasItemUpdater : BaseItemUpdater
    {
        public static new SulfurasItemUpdater Instance
        {
            get => _sulfurasItemUpdater;
        }
        private static SulfurasItemUpdater _sulfurasItemUpdater = new SulfurasItemUpdater();

        public override void Update(Item item)
        {
        }
    }
}
