using System;
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

		public string load() { return ""; }
	}
}
