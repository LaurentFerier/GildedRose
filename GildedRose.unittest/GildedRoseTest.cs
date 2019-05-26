using GildedRose.Items;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            Stock stock = new Stock();
            stock.AddItem(new Item { Name = "foo", SellIn = 0, Quality = 0 });
            stock.UpdateQuality();
            Assert.AreEqual("foo", stock[0].Name);
        }
    }
}
