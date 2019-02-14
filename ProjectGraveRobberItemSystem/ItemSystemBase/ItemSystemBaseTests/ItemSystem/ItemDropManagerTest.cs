using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSystemBase.FileHandler;
using ItemSystemBase.ItemSystem;

namespace ItemSystemBaseTests.ItemSystem
{
	[TestClass]
	public class ItemDropManagerTest
	{

		[TestMethod]
		public void constructor01()
		{
			ItemDropManager idm = new ItemDropManager();
		}

		[TestMethod]
		public void constructor02()
		{
			SaveFileHandler sfh = new SaveFileHandler();
			ItemDropManager idm = new ItemDropManager(sfh);
		}

		[TestMethod]
		public void constructor03()
		{
			Item[] items = new Item[4];
			items[0] = new Item("1", 1);
			items[1] = new Item("2", 2);
			items[2] = new Item("3", 3);
			items[3] = new Item("4", 4);
			ItemDropManager idm = new ItemDropManager(items);
		}

		[TestMethod]
		public void getCountRNGItems01()
		{
			Item[] items = new Item[4];
			items[0] = new Item("1", 1);
			items[1] = new Item("2", 2);
			items[2] = new Item("3", 3);
			items[3] = new Item("4", 4);
			ItemDropManager idm = new ItemDropManager(items);
			int desiredNumberOfItems = 4;


			Item[] itemsRecieved = idm.getCountRNGItems(desiredNumberOfItems);

			Assert.AreEqual(desiredNumberOfItems, itemsRecieved.Length);
		}

		[TestMethod]
		public void getCountRNGItems02()
		{
			Item[] items = new Item[1];
			items[0] = new Item("1", 1);
			ItemDropManager idm = new ItemDropManager(items);
			int desiredNumberOfItems = 0;

			Item[] itemsRecieved = idm.getCountRNGItems(desiredNumberOfItems);

			Assert.AreEqual(desiredNumberOfItems, itemsRecieved.Length);
		}

		[TestMethod]
		public void getCountRNGItems03()
		{
			Item[] items = new Item[1];
			items[0] = new Item("1", 1);
			ItemDropManager idm = new ItemDropManager(items);
			int desiredNumberOfItems = 30;

			Item[] itemsRecieved = idm.getCountRNGItems(desiredNumberOfItems);

			Assert.AreEqual(desiredNumberOfItems, itemsRecieved.Length);
		}
	}
}
