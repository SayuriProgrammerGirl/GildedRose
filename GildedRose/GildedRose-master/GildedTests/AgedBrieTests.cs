using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedTests
{
    [TestClass]
    public class AgedBrieTests
    {
        private Program program;
        private Item item;

        [TestInitialize]
        public void Setup()
        {
            program = new Program();
            item = new Item { Name = "Aged Brie" };
            program.SetItems(new List<Item>() { item });
        }


        [TestMethod]
        public void WhenQualityAtLeast50AndStillDaysToSellQualityRemainsTheSame()
        {
            item.SellIn = 2;
            item.Quality = 50;

            program.UpdateQuality();

            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(1,item.SellIn);
        }

        [TestMethod]
        public void WhenQualityAtLeast50AndNoMoreDaysToSellQualityRemainsTheSame()
        {
            item.SellIn = 0;
            item.Quality = 50;
            
            program.UpdateQuality();

            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [TestMethod]
        public void WhenStillMoreDaysToSellQualityIncreaseByOne()
        {
            item.SellIn = 10;
            item.Quality = 1;
            
            program.UpdateQuality();

            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(9, item.SellIn);
        }

        [TestMethod]
        public void WhenNoMoreDaysToSellQualityIncreaseByTwo()
        {
            item.SellIn = 0;
            item.Quality = 1;

            program.UpdateQuality();

            Assert.AreEqual(3, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }
    }
}
