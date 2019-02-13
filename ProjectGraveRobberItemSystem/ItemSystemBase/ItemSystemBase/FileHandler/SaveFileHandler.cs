using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ItemSystemBase.ItemSystem;

namespace ItemSystemBase.FileHandler
{
	class SaveFileHandler
	{
		readonly AssetManager assetManager;

		public SaveFileHandler(AssetManager assetManager)
		{
			this.assetManager = assetManager;
		}

        /** Loads all items from the xml file and returns an item array with all items. */
		public Item[] loadAllItems()
		{
            //Load the xml file containing all items.
            XmlDocument allItemsFileXml = new XmlDocument();
            allItemsFileXml.Load(assetManager.getAllItemsFilePath());

            //Should be a list of all items in xml format
            XmlNodeList allXmlItems = allItemsFileXml.DocumentElement.ChildNodes;
            //Console.WriteLine(allXmlItems.Count); //Number of items/elements in file.

            //Create and fill array of items
            Item[] allItems = new Item[allXmlItems.Count];
            for(int i = 0; i < allXmlItems.Count; i++)
            {
                allItems[i] = new Item(allXmlItems[i].ChildNodes[0].InnerText, int.Parse(allXmlItems[i].ChildNodes[1].InnerText));
            }

            /* MAY BE DELETED: Used for testing
            foreach (XmlNode node in allXmlItems)
            {
                Console.Write("Item Name: " + node.ChildNodes[0].InnerText);
                Console.WriteLine(" ID: " + node.ChildNodes[1].InnerText);
            }*/

            /* MAY BE DELETED: Used for testing
            foreach (Item item in allItems)
            {
                Console.Write(item.id);
                Console.WriteLine(item.name);
            }*/

            return allItems;
		}

		/** Saves the given inventory to the saveFile. */
        public Boolean saveInventory(Inventory inventory)
        {
            String saveString = inventory.getSaveString();

			if (File.Exists(assetManager.getSaveFilePath()))
			{
				System.IO.File.WriteAllText(assetManager.getSaveFilePath(), saveString);
				return true;
			}

			return false;
        }

		/** Returns the inventory saved in the saveFile. */
		public Inventory loadInventory()
		{
			//Get the char array that represents what needs to be loaded.
			string inventorySaveString = loadInventorySaveString();
			string[] saveStringItems = getSavesInventoryStrings();


			//char[] saveStringItems = inventorySaveString.ToCharArray();

			Item[] allItem = loadAllItems(); //All possible items in the game
			InventorySlot[] finalInventorySlots = new InventorySlot[GameInfo.i_intentorySize];

			//Does the lenght of the string match the wanted lengh/size of inventory?
			if (saveStringItems.Length != finalInventorySlots.Length)
				throw new ArgumentException();

			//Convert the saveString into inventorySlots
			for(int i = 0; i < saveStringItems.Length; i++)
			{
				Item itemToAdd = getItemFromId(saveStringItems[i], allItem);
				finalInventorySlots[i] = new InventorySlot();

				if(itemToAdd != null)
					finalInventorySlots[i].addItem(itemToAdd);
			}

			return new Inventory(finalInventorySlots);
		}

		/** Returns the item matching the given id. Returns null if non is found or char is blank char. */
		private Item getItemFromId(string id, Item[] allPossibleItems)
		{
			//If the id given is a blank char (no item)
			if(id.Length == 1)
				if (id[0] == GameInfo.i_emptySlotChar)
					return null;

			foreach (Item item in allPossibleItems)
			{
				if(int.Parse(id).Equals(item.id))
				{
					return new Item(item.name, item.id);
				}
			}

			return null;
		}

		/** Return string array where each element is an item-id. */
		private string[] getSavesInventoryStrings()
		{
			string saveString = loadInventorySaveString();
			string[] inventoryString = saveString.Split(GameInfo.i_charItemSpacer);

			List<string> inventoryStrings = new List<string>();
			
			foreach (string s in inventoryString)
			{
				if (s.Length != 0)
					inventoryStrings.Add(s);
			}

			return inventoryStrings.ToArray();
		}

		/** Returns the inventory string saved in the saveFile. Will return null if action fails. */
		private string loadInventorySaveString()
		{
			string inventoryString = null;

			if (File.Exists(assetManager.getSaveFilePath()))
			{
				inventoryString = System.IO.File.ReadAllText(assetManager.getSaveFilePath());
			}

			return inventoryString;
		}
	}
}
