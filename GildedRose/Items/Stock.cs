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
        public IList<Item> Items { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Stock()
        {
            Items = new List<Item>();
        }

        /// <summary>
        /// Adds a new item in the stock.
        /// </summary>
        /// <param name="new_item"></param>
        /// <returns>true if the item could be added in the stock</returns>
        public bool AddItem(Item new_item)
        {
            Items.Add(new_item);

            return true;
        }

        /// <summary>
        /// Accesses the ith element
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Item this[int i]
        {
            get { return Items[i]; }
            set { Items[i] = value; }
        }

        /// <summary>
        /// Updates the quality of all items in the stock
        /// </summary>
        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality = item.Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    item.Quality = item.Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            item.Quality = item.Quality - item.Quality;
                        }
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Dumps the contents of the stock using the textwriter provided
        /// </summary>
        /// <param name="writer"></param>
        public void Dump(TextWriter writer)
        {
            writer.WriteLine("name, sellIn, quality");
            foreach (Item item in Items)
            {
                writer.WriteLine(item);
            }
            writer.WriteLine("");
        }
    }
}
