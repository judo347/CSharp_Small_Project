using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSystemBase.ItemSystem;
using ItemSystemBase;

namespace ItemSystemBaseTests.ItemSystem
{
    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void contructor01()
        {
            Inventory inventory = new Inventory();

            //Right size
            Assert.IsTrue((inventory.getSizeOfInventory()).Equals(GameInfo.i_intentorySize));

            //Slots are initialized and are empty
            InventorySlot[] slotsArray = inventory.getSlotsArray();
            for(int i = 0; i < GameInfo.i_intentorySize; i++)
            {
                Assert.IsNotNull(slotsArray[i]);
                Assert.IsTrue(slotsArray[i].isFree);
            }
                
        }

        [TestMethod]
        public void addItem01()
        {
            Inventory inventory = new Inventory();
            Item item = new Item("Test Item", 5);

            Boolean addStatus = inventory.addItem(item);
            InventorySlot[] slotsArray = inventory.getSlotsArray();

            Assert.IsTrue(addStatus);
            Assert.AreEqual(item, slotsArray[0].item);
        }

        [TestMethod]
        public void addItem02()
        {
            Inventory inventory = new Inventory();
            Item item = new Item("Test Item", 5);

            for(int i = 0; i < inventory.getSizeOfInventory(); i++)
            {
                inventory.addItem(item);
            }

            Boolean addStatus = inventory.addItem(item);

            Assert.IsFalse(addStatus);
        }
    }
}
