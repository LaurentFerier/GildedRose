namespace GildedRose.Items.Updaters
{
    public class ConcertTicketUpdater : BaseUpdater
    {
        /// <summary>
        /// Updates value for concert tickets 
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateItem(Item item)
        {
            // [R4.6]
            if ( item.SellIn > 10 )
            {
                UpdateItemQuality(item, item.Quality + 1);
            }
            else if ( item.SellIn > 5 )
            {
                UpdateItemQuality(item, item.Quality + 2);
            }
            else if (item.SellIn > 0)
            {
                UpdateItemQuality(item, item.Quality + 3);
            }
            else
            {
                item.Quality = 0;
            }

            item.SellIn = item.SellIn - 1;
        }

        /// <summary>
        /// Singleton 
        /// </summary>
        public static IItemUpdater Instance { get; private set; } = new ConcertTicketUpdater();
    }
}
