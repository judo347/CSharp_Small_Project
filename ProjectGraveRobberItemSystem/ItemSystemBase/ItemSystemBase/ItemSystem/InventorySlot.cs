using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemSystemBase.ItemSystem
{
	class InventorySlot
	{
		public Boolean isFree = true;
		public Item item = null;

		/** Adds the given item to this slot. Returns true if request was successful. */
		public Boolean addItem(Item item)
		{
			if (isFree)
			{
				this.item = item;
				this.isFree = false;
				return true;
			}

			return false;
		}

		/** Removes and returns current item. Returns null if no item is in this slot. */
		public Item popItem()
		{
			if (item != null)
			{
				Item item = this.item;
				this.item = null; //TODO Does this work?
				this.isFree = true;
				return item;
			}

			return null;
		}
	}
}
