using GildedRose.Items;
using System;

namespace GildedRose
{
    /// <summary>
    /// This program updates the quality & value of all items in the stock during 31 days
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            Stock stock = new Stock();
            stock.AddItem(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });
            stock.AddItem(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });
            stock.AddItem(new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 });
            stock.AddItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
            stock.AddItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 });
            stock.AddItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 });
            stock.AddItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 });
            stock.AddItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 });

            // this conjured item does not work properly yet
            stock.AddItem(new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });

            for (int i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                stock.Dump(Console.Out);
                stock.UpdateQuality();
            }
        }
    }
}
