namespace GildedRose.Items.Updaters
{
    public interface IItemUpdater
    {
        /// <summary>
        /// Updates the properties of the item
        /// </summary>
        /// <param name="item"></param>
        void UpdateItem(Item item);
    }
}
