namespace GildedRose.Items.Updaters
{
    public class DefaultUpdater : BaseUpdater
    {
        /// <summary>
        /// Decreases both SellIn and Quality (update done by default)
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateItem(Item item)
        {
            if (item.SellIn > 0)
            {
                //[R4.1]
                UpdateItemQuality(item, item.Quality - 1);
            }
            else
            {
                //[R4.2]
                UpdateItemQuality(item, item.Quality - 2);
            }

            base.UpdateItem(item);
        }

        /// <summary>
        /// Singleton 
        /// </summary>
        public static IItemUpdater Instance { get; private set; } = new DefaultUpdater();
    }
}
