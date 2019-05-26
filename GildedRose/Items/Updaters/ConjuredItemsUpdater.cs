using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Items.Updaters
{
    public class ConjuredItemsUpdater : BaseUpdater
    {
        /// <summary>
        /// Conjured items' quality decreases twice as fast as normal items
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateItem(Item item)
        {
            // [R.6]
            if (item.SellIn > 0)
            {
                UpdateItemQuality(item, item.Quality - 2);
            }
            else
            {
                UpdateItemQuality(item, item.Quality - 4);
            }

            base.UpdateItem(item);
        }

        /// <summary>
        /// Singleton 
        /// </summary>
        public static IItemUpdater Instance { get; private set; } = new ConjuredItemsUpdater();

    }
}
