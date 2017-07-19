using System;
using System.Collections.Generic;
using System.Security.Policy;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedTests
{
    [TestClass]
    public class AgedBrieTests
    {
        [TestMethod]
        public void WhenQualityAtLeast50AndStillDaysToSellQualityRemainsTheSame()
        {
            var program = new Program();
            var item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 };

            program.SetItems(new List<Item>() { item });

            program.UpdateQuality();

            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(1,item.SellIn);
        }

        [TestMethod]
        public void WhenQualityAtLeast50AndNoMoreDaysToSellQualityRemainsTheSame()
        {
            var program = new Program();
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 };

            program.SetItems(new List<Item>() { item });

            program.UpdateQuality();

            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [TestMethod]
        public void WhenStillMoreDaysToSellQualityIncreaseByOne()
        {
            var program = new Program();
            var item = new Item { Name = "Aged Brie", SellIn = 10, Quality = 1 };

            program.SetItems(new List<Item>() { item });

            program.UpdateQuality();

            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [TestMethod]
        public void WhenNoMoreDaysToSellQualityIncreaseByTwo()
        {
            var program = new Program();
            var item = new Item { Name = "Aged Brie", SellIn = 0, Quality = 1 };

            program.SetItems(new List<Item>() { item });

            program.UpdateQuality();

            Assert.AreEqual(3, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }
    }
}
