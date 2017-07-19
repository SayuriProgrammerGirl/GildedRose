using System.Collections.Generic;
using GildedRose.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedTests
{
    [TestClass]
    public class SulfurasTests
    {
        private Program program;
        private Item item;

        [TestInitialize]
        public void Setup()
        {
            program = new Program();
            item = new Item { Name = "Sulfuras, Hand of Ragnaros" };
            program.SetItems(new List<Item>() { item });
        }

        [TestMethod]
        public void KeepsItsPropertiesIntactIfSellInNotReached()
        {
            item.SellIn = 1;
            item.Quality = 0;

            program.UpdateQuality();

            Assert.AreEqual(0,item.Quality);
            Assert.AreEqual(1,item.SellIn);
        }

        [TestMethod]
        public void KeepsItsPropertiesIntacyIfSellInReached()
        {
            item.SellIn = 0;
            item.Quality = 10;

            program.UpdateQuality();

            Assert.AreEqual(10, item.Quality);
            Assert.AreEqual(0, item.SellIn);
        }
    }
}
