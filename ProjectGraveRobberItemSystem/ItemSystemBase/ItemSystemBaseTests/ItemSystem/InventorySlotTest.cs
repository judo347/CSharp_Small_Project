using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSystemBase.ItemSystem;

namespace ItemSystemBaseTests.ItemSystem
{
	[TestClass]
	public class InventorySlotTest
	{
		[TestMethod]
		public void constructor01()
		{
			InventorySlot inventorySlot = new InventorySlot();
			Assert.IsTrue(inventorySlot.isFree);
		}

		[TestMethod]
		public void constructor02()
		{
			InventorySlot inventorySlot = new InventorySlot();
			Assert.IsNull(inventorySlot.item);
		}

		[TestMethod]
		public void addItem01()
		{
			InventorySlot inventorySlot = new InventorySlot();
			Item item = new Item("Test Item", 5);

			Boolean addStatus = inventorySlot.addItem(item);

			Assert.IsTrue(addStatus);
			Assert.IsFalse(inventorySlot.isFree);
			Assert.IsNotNull(inventorySlot.item);
		}

		[TestMethod]
		public void addItem02()
		{
			InventorySlot inventorySlot = new InventorySlot();
			Item item1 = new Item("Test Item", 5);
			Item item2 = new Item("Test item 2", 3);

			inventorySlot.addItem(item1);
			Boolean secondAddStatus = inventorySlot.addItem(item2);

			Assert.IsFalse(secondAddStatus);
			Assert.IsFalse(inventorySlot.isFree);
			Assert.IsNotNull(inventorySlot.item);
		}

		[TestMethod]
		public void popItem01()
		{
			InventorySlot inventorySlot = new InventorySlot();

			Item item = inventorySlot.popItem();

			Assert.IsNull(item);
		}

		[TestMethod]
		public void popItem02()
		{
			InventorySlot inventorySlot = new InventorySlot();
			String itemName = "Test Item 1";
			int itemId = 5;
			Item item1 = new Item(itemName, itemId);

			Boolean addStatus = inventorySlot.addItem(item1);

			Assert.IsTrue(addStatus);
			Assert.IsNotNull(inventorySlot.item);

			Item poppedItem = inventorySlot.popItem();

			Assert.IsTrue(inventorySlot.isFree);
			Assert.IsNull(inventorySlot.item);
			Assert.IsNotNull(poppedItem);
			Assert.IsTrue(itemName.Equals(poppedItem.name));
			Assert.IsTrue(itemId.Equals(poppedItem.id));
		}
	}
}
