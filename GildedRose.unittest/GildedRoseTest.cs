using GildedRose.Items;
using GildedRose.Items.Updaters;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose
{
    [TestFixture]
    public class GildedRoseTest
    {
        /// <summary>
        /// Describes the expectations for a single step of the test
        /// </summary>
        private class Expectation
        {
            /// <summary>
            /// The expected quality value
            /// </summary>
            public int Quality { get; private set; }

            /// <summary>
            /// The expected SellIn value
            /// </summary>
            public int SellIn { get; private set; }

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="quality"></param>
            /// <param name="sell_in"></param>
            public Expectation(int quality, int sell_in)
            {
                Quality = quality;
                SellIn = sell_in;
            }

            /// <summary>
            /// Asserts that the item respects its expectations
            /// </summary>
            /// <param name="item"></param>
            public void CheckItem(Item item)
            {
                Assert.AreEqual(Quality, item.Quality);
                Assert.AreEqual(SellIn, item.SellIn);
            }
        }

        /// <summary>
        /// The stock used to perform the tests
        /// </summary>
        private Stock Stock { get; set; }

        /// <summary>
        /// The expected item evolution
        /// </summary>
        private List<Expectation> Expectations { get; set; }

        /// <summary>
        /// Ensures that the item respects the evolution described in the list of expectations
        /// </summary>
        /// <param name="item"></param>
        /// <param name="expectations"></param>
        private void CheckItemEvolution(Item item)
        {
            foreach (Expectation expectation in Expectations)
            {
                Stock.UpdateQuality();
                expectation.CheckItem(item);
            }
        }

        [SetUp]
        public void Setup()
        {
            Stock = new Stock();
            Expectations = new List<Expectation>();
        }

        /// <summary>
        /// Tests the default updater
        /// </summary>
        [Test]
        public void TestDefaultUpdater1()
        {
            Item item = new Item { Name = "foo", SellIn = 5, Quality = 10 };
            Stock.AddItem(item, DefaultUpdater.Instance);

            // [R4.1]
            Expectations.Add(new Expectation(9, 4));
            Expectations.Add(new Expectation(8, 3));
            Expectations.Add(new Expectation(7, 2));
            Expectations.Add(new Expectation(6, 1));
            Expectations.Add(new Expectation(5, 0));

            // [R4.2]
            Expectations.Add(new Expectation(3, -1));
            Expectations.Add(new Expectation(1, -2));

            // [R4.3]
            Expectations.Add(new Expectation(0, -3));
            Expectations.Add(new Expectation(0, -4));

            CheckItemEvolution(item);
        }

        /// <summary>
        /// Tests the default updater according to regressions in ThirtyDays example
        /// </summary>
        [Test]
        public void TestDefaultUpdater2()
        {
            Item item = new Item { Name = "Cake", SellIn = 0, Quality = 3 };
            Stock.AddItem(item, DefaultUpdater.Instance);

            Expectations.Add(new Expectation(1, -1));

            CheckItemEvolution(item);
        }

        /// <summary>
        /// Tests the legendary updater 
        /// </summary>
        [Test]
        public void TestLegendaryUpdater()
        {
            Item item = new Item { Name = "Sulfuras", SellIn = 5, Quality = 1515 };
            Stock.AddItem(item, LegendaryItemUpdater.Instance);

            // [R5] and [R7]
            Expectations.Add(new Expectation(1515, 5));

            CheckItemEvolution(item);
        }

        /// <summary>
        /// Tests the cheese updater
        /// </summary>
        [Test]
        public void TestCheeseUpdater()
        {
            Item item = new Item { Name = "Blue cheese", SellIn = 5, Quality = 3 };
            Stock.AddItem(item, CheeseUpdater.Instance);

            // [R4.5] 
            Expectations.Add(new Expectation(4, 4));

            CheckItemEvolution(item);

            // [R4.4]
            for (int i = 0; i < 100; i++)
            {
                Stock.UpdateQuality();
            }
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
            Expectations.Add(new Expectation(4, 11));
            Expectations.Add(new Expectation(5, 10));
            Expectations.Add(new Expectation(7, 9));
            Expectations.Add(new Expectation(9, 8));
            Expectations.Add(new Expectation(11, 7));
            Expectations.Add(new Expectation(13, 6));
            Expectations.Add(new Expectation(15, 5));
            Expectations.Add(new Expectation(18, 4));
            Expectations.Add(new Expectation(21, 3));
            Expectations.Add(new Expectation(24, 2));
            Expectations.Add(new Expectation(27, 1));
            Expectations.Add(new Expectation(30, 0));
            Expectations.Add(new Expectation(0, -1));
            Expectations.Add(new Expectation(0, -2));

            CheckItemEvolution(item);
        }

        /// <summary>
        /// Tests the conjured item updater
        /// </summary>
        [Test]
        public void TestConjuredItemsUpdater()
        {
            Item item = new Item { Name = "Conjured meatball", SellIn = 5, Quality = 17 };
            Stock.AddItem(item, ConjuredItemsUpdater.Instance);

            // [R6]
            Expectations.Add(new Expectation(15, 4));
            Expectations.Add(new Expectation(13, 3));
            Expectations.Add(new Expectation(11, 2));
            Expectations.Add(new Expectation(9, 1));
            Expectations.Add(new Expectation(7, 0));
            Expectations.Add(new Expectation(3, -1));
            Expectations.Add(new Expectation(0, -2));

            CheckItemEvolution(item);
        }
    }
}
