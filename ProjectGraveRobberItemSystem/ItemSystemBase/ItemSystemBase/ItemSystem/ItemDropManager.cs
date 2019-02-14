using ItemSystemBase.FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemSystemBase.ItemSystem
{
	/** This manager is used to handle all behaviour regarding items dropping.
	 This should be the top hierachy class and all class should go through 
	 this class when asking for item drops. */
	class ItemDropManager
	{
		//FIELDS
		readonly private Item[] allIngameItems;

		//CONTRUCTORS
		public ItemDropManager() : this(new SaveFileHandler()) { }

		public ItemDropManager(SaveFileHandler saveFileHandler) : this(saveFileHandler.loadAllIngameItems()) { }
		
		public ItemDropManager(Item[] allIngameItems)
		{
			if (allIngameItems.Length == 0)
				throw new ArgumentException();

			this.allIngameItems = allIngameItems;
		}

		//METHODS
		/** Returns the given about of items chosen at random. */
		public Item[] getCountRNGItems(int desiredAmount)
		{
			if (desiredAmount < 0)
				throw new ArgumentException();

			Item[] desiredItems = new Item[desiredAmount];
			Random rng = new Random();

			//Get the desired number of items
			for(int i = 0; i < desiredAmount; i++)
			{
				desiredItems[i] = allIngameItems[rng.Next(allIngameItems.Length)].copy();
			}

			return desiredItems;
		}
	}
}
