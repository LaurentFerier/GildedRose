namespace GildedRose.Items.Updaters
{
    public class CheeseUpdater : BaseUpdater
    {
        /// <summary>
        /// Updates value according to cheese ageing process
        /// </summary>
        /// <param name="item"></param>
        public override void UpdateItem(Item item)
        {
            if (item.SellIn > 0)
            {
                // [R4.5]
                UpdateItemQuality(item, item.Quality + 1);
            }
            else
            {
                // [R4.5] and [R4.2]
                UpdateItemQuality(item, item.Quality + 2);
            }

            base.UpdateItem(item);
        }

        /// <summary>
        /// Singleton 
        /// </summary>
        public static IItemUpdater Instance { get; private set; } = new CheeseUpdater();
    }
}
