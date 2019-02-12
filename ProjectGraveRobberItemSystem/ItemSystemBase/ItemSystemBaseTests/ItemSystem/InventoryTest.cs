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

		[TestMethod]
		public void getSaveString01()
		{
			Inventory inventory = new Inventory();
			String saveString = inventory.getSaveString();

			//Is the lengh of the string the same as number of inventory slots?
			Assert.AreEqual(saveString.Length, GameInfo.i_intentorySize);

			//Is all chars in the string the same as the charactor for EmptySlot?
			char[] saveStringChars = saveString.ToCharArray();
			for (int i = 0; i < saveString.Length; i++)
				Assert.AreEqual(saveStringChars[i], GameInfo.i_emptySlotChar);
		}

		[TestMethod]
		public void getSaveString02()
		{
			Inventory inventory = new Inventory();
			Item item = new Item("Test Item", 5);
			char five = '5';

			inventory.addItem(item);
			String saveString = inventory.getSaveString();
			char[] saveStringChars = saveString.ToCharArray();

			Assert.AreEqual(saveStringChars[0], five);
		}
	}
}
