using System;

namespace GildedRose.Items.Updaters
{
    /// <summary>
    /// The base class for item quality updater
    /// </summary>
    public abstract class BaseUpdater : IItemUpdater
    {
        /// <summary>
        /// Updates the item attributes
        /// </summary>
        /// <param name="item"></param>
        public virtual void UpdateItem(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        /// <summary>
        /// Updates the quality of the item with the provided value
        /// </summary>
        /// <param name="item">The item to update</param>
        /// <param name="value">The new item Quality value</param>
        protected void UpdateItemQuality(Item item, int value )
        {
            // [R4.3] and [R4.4]
            item.Quality = Math.Max(0, Math.Min(50, value));
        }
    }
}
