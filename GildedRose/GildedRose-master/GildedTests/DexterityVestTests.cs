using System;
using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedTests
{
    [TestClass]
    public class DexterityVestTests
    {
        readonly Program program = new Program();
        private Item item;

        [TestInitialize]
        public void Setup()
        {
            item = new Item { Name = "+5 Dexterity Vest" };
            program.SetItems(new List<Item> { item });
        }

        [TestMethod]
        public void WhenStillDaysToSellQualityDecreasesByOne()
        {
            item.SellIn = 10;
            item.Quality = 20;

            program.UpdateQuality();

            Assert.AreEqual(19, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [TestMethod]
        public void WhenNoMoreDaysToSellQualityDecreasesByTwo()
        {
            item.SellIn = 0;
            item.Quality = 20;

            program.UpdateQuality();

            Assert.AreEqual(18, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [TestMethod]
        public void WhenQualityReachesZeroThereIsNoMoreDecreaseInQuality()
        {
            item.SellIn = 0;
            item.Quality = 0;

            program.UpdateQuality();

            Assert.AreEqual(-1, item.SellIn);
            Assert.AreEqual(0, item.Quality);
        }
    }
}
