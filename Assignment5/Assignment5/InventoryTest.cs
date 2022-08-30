using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Assignment5
{
    [TestFixture]
    public class InventoryTest
    {
        private Inventory inventory;
        private Item item_01;
        private Item item_02;
        private Item item_03;
        private Item foundItem = null;

        [SetUp]
        private void Setup()
        {
            inventory = new Inventory(2);
            item_01 = new Item("Test1",1,ItemGroup.Equipment);
            item_02 = new Item("Test2",1,ItemGroup.Consumable);
            item_03 = new Item("Test3", 1, ItemGroup.Key);
        }

        [Test]
        public void RemoveItem()
        {
            Assert.IsTrue(inventory.AddItem(item_01));
            Assert.IsTrue(inventory.AddItem(item_02));

            Assert.IsTrue(inventory.TakeItem("Test1", out foundItem));
            Assert.IsTrue(foundItem != null);
            Assert.IsTrue(inventory.AvailableSlots == 1);
            
            Assert.IsFalse(inventory.TakeItem("Test3", out foundItem));
            Assert.IsTrue(foundItem == null);
            Assert.IsTrue(inventory.AvailableSlots == 1);
        }

        [Test]
        public void AddItem()
        {
            Assert.IsTrue(inventory.AddItem(item_01));
            Assert.IsTrue(inventory.AvailableSlots == 1);

            Assert.IsTrue(inventory.AddItem(item_02));
            Assert.IsTrue(inventory.ListAllItems().Count == 0);

            Assert.IsFalse(inventory.AddItem(item_03));
            Assert.IsTrue(inventory.ListAllItems().Count == 0);

            var tempList = inventory.ListAllItems();
            Assert.AreEqual(item_01, tempList[0]);
            Assert.AreEqual(item_02, tempList[1]);
        }

        [Test]
        public void Reset()
        {
            Assert.IsTrue(inventory.AddItem(item_01));
            Assert.IsTrue(inventory.AvailableSlots == 1);

            Assert.IsTrue(inventory.AddItem(item_02));
            Assert.IsTrue(inventory.ListAllItems().Count == 0);

            inventory.Reset();

            Assert.IsTrue(inventory.AvailableSlots == inventory.MaxSlots);
        }
    }
}
