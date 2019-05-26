namespace GildedRose.Items
{
    /// <summary>
    /// The base item stored in the stock
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The item name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The SellIn value of the Item [R3]
        /// </summary>
        public int SellIn { get; set; }

        /// <summary>
        /// The Item Quality [R2.1]
        /// </summary>
        public int Quality { get; set; }

        public override string ToString()
        {
            return Name + ", " + SellIn + ", " + Quality;
        }  
    }
}
