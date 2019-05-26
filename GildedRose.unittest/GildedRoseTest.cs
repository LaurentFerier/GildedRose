using GildedRose.Items;
using GildedRose.Items.Updaters;
using NUnit.Framework;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        /// <summary>
        /// The stock used to perform the tests
        /// </summary>
        private Stock Stock { get; set; }

        [SetUp]
        public void Setup()
        {
            Stock = new Stock();
        }

        /// <summary>
        /// Tests the default updater
        /// </summary>
        [Test]
        public void TestDefaultUpdater1()
        {
            Item item = new Item { Name = "foo", SellIn = 5, Quality = 10 };
            Stock.AddItem(item, DefaultUpdater.Instance);
            Stock.UpdateQuality();
            // [R4.1]
            Assert.AreEqual(9, item.Quality);
            Assert.AreEqual(4, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(8, item.Quality);
            Assert.AreEqual(3, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(7, item.Quality);
            Assert.AreEqual(2, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(6, item.Quality);
            Assert.AreEqual(1, item.SellIn);
            Stock.UpdateQuality();

            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(0, item.SellIn);
            Stock.UpdateQuality();
            // [R4.2]
            Assert.AreEqual(3, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(1, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
            Stock.UpdateQuality();
            // [R4.3]
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-3, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-4, item.SellIn);
        }

        /// <summary>
        /// Tests the default updater according to regressions in ThirtyDays example
        /// </summary>
        [Test]
        public void TestDefaultUpdater2()
        {
            Item item = new Item { Name = "Cake", SellIn = 0, Quality = 3 };
            Stock.AddItem(item, DefaultUpdater.Instance);
            Stock.UpdateQuality();
            Assert.AreEqual(1, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        /// <summary>
        /// Tests the legendary updater 
        /// </summary>
        [Test]
        public void TestLegendaryUpdater()
        {
            Item item = new Item { Name = "Sulfuras", SellIn = 5, Quality = 1515 };
            Stock.AddItem(item, LegendaryItemUpdater.Instance);
            Stock.UpdateQuality();
            // [R5] and [R7]
            Assert.AreEqual(1515, item.Quality);
            Assert.AreEqual(5, item.SellIn);
        }

        /// <summary>
        /// Tests the cheese updater
        /// </summary>
        [Test]
        public void TestCheeseUpdater()
        {
            Item item = new Item { Name = "Blue cheese", SellIn = 5, Quality = 3 };
            Stock.AddItem(item, CheeseUpdater.Instance);
            Stock.UpdateQuality();
            // [R4.5] 
            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(4, item.SellIn);

            for (int i = 0; i < 100; i++)
            {
                Stock.UpdateQuality();
            }

            // [R4.4]
            Assert.AreEqual(50, item.Quality);

        }

        /// <summary>
        /// Tests the ticket updater
        /// </summary>
        [Test]
        public void TestTicketUpdater()
        {
            Item item = new Item { Name = "Ticket", SellIn = 12, Quality = 3 };
            Stock.AddItem(item, ConcertTicketUpdater.Instance);
            // [R4.6] 
            Stock.UpdateQuality();
            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(11, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(5, item.Quality);
            Assert.AreEqual(10, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(7, item.Quality);
            Assert.AreEqual(9, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(9, item.Quality);
            Assert.AreEqual(8, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(11, item.Quality);
            Assert.AreEqual(7, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(13, item.Quality);
            Assert.AreEqual(6, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(15, item.Quality);
            Assert.AreEqual(5, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(18, item.Quality);
            Assert.AreEqual(4, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(21, item.Quality);
            Assert.AreEqual(3, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(24, item.Quality);
            Assert.AreEqual(2, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(27, item.Quality);
            Assert.AreEqual(1, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(30, item.Quality);
            Assert.AreEqual(0, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
        }

        /// <summary>
        /// Tests the conjured item updater
        /// </summary>
        [Test]
        public void TestConjuredItemsUpdater()
        {
            Item item = new Item { Name = "Conjured meatball", SellIn = 5, Quality = 17 };
            Stock.AddItem(item, ConjuredItemsUpdater.Instance);
            Stock.UpdateQuality();
            // [R6]
            Assert.AreEqual(15, item.Quality);
            Assert.AreEqual(4, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(13, item.Quality);
            Assert.AreEqual(3, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(11, item.Quality);
            Assert.AreEqual(2, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(9, item.Quality);
            Assert.AreEqual(1, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(7, item.Quality);
            Assert.AreEqual(0, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(3, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
            Stock.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-2, item.SellIn);
        }
    }
}
