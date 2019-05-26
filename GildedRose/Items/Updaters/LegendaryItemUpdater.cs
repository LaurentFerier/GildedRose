namespace GildedRose.Items.Updaters
{
    public class LegendaryItemUpdater : IItemUpdater
    {
        /// <summary>
        /// Updates value for legendary items
        /// </summary>
        /// <param name="item"></param>
        public void UpdateItem(Item item)
        {
            // [R5] No change
        }

        /// <summary>
        /// Singleton 
        /// </summary>
        public static IItemUpdater Instance { get; private set; } = new LegendaryItemUpdater();
    }
}
