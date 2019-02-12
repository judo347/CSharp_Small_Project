using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSystemBase.ItemSystem;

namespace ItemSystemBaseTests.ItemSystem
{
	[TestClass]
	public class ItemTest
	{
		[TestMethod]
		public void constructor01()
		{
			String itemName = "ItemName";
			int itemId = 5;
			Item item = new Item(itemName, itemId);
			Assert.IsTrue(itemName.Equals(item.name));
			Assert.IsTrue(itemId.Equals(item.id));
		}
	}
}
