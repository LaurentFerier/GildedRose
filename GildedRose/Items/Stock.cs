using GildedRose.Items.Updaters;
using System.Collections.Generic;
using System.IO;

namespace GildedRose.Items
{
    /// <summary>
    /// Handles the Gilded Rose stock
    /// </summary>
    public class Stock
    {
        /// <summary>
        /// Holds the items stored in the stock
        /// </summary>
        public IList<KeyValuePair<Item, IItemUpdater>> Items { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Stock()
        {
            Items = new List<KeyValuePair<Item, IItemUpdater>>();
        }

        /// <summary>
        /// Adds a new item in the stock.
        /// </summary>
        /// <param name="new_item"></param>
        /// <returns>true if the item could be added in the stock</returns>
        public bool AddItem(Item new_item, IItemUpdater updater)
        {
            Items.Add(new KeyValuePair<Item, IItemUpdater>(new_item, updater));

            return true;
        }

        /// <summary>
        /// Accesses the ith element
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Item this[int i]
        {
            get { return Items[i].Key; }
        }

        /// <summary>
        /// Updates the quality of all items in the stock
        /// </summary>
        public void UpdateQuality()
        {
            foreach (KeyValuePair<Item, IItemUpdater> pair in Items)
            {
                pair.Value.UpdateItem(pair.Key);
            }
        }

        /// <summary>
        /// Dumps the contents of the stock using the textwriter provided
        /// </summary>
        /// <param name="writer"></param>
        public void Dump(TextWriter writer)
        {
            writer.WriteLine("name, sellIn, quality");
            foreach (KeyValuePair<Item, IItemUpdater> pair in Items)
            {
                writer.WriteLine(pair.Key);
            }
            writer.WriteLine("");
        }
    }
}
