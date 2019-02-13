using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemSystemBase.ItemSystem
{
    class Inventory
    {
		private InventorySlot[] slotsArray;

        public Inventory()
        {
			slotsArray = new InventorySlot[GameInfo.i_intentorySize];


			for (int i = 0; i < GameInfo.i_intentorySize; i++)
            {
                slotsArray[i] = new InventorySlot();
            }
        }

		public Inventory(InventorySlot[] inventoryItems)
		{
			//Does the given array match the size of the inventory
			if (inventoryItems.Length != GameInfo.i_intentorySize)
				throw new ArgumentException();

			slotsArray = inventoryItems;
		}

        /** Adds the given item to the first empty slot. Returns true if action was successful. */
        public Boolean addItem(Item item)
        {
            InventorySlot emptySlot = getFirstEmptySlot();

            if(emptySlot != null)
            {
                emptySlot.addItem(item);
                return true;
            }

            return false;
        }

        /** @Return the first empty slot. Returns null if non were found. */
        private InventorySlot getFirstEmptySlot()
        {
            for(int i = 0; i < GameInfo.i_intentorySize; i++)
            {
                if (slotsArray[i].isFree)
                    return slotsArray[i];
            }

            return null;
        }

        /** @returns the string used to save this inventory. */
        public String getSaveString()
        {
            String saveString = "";

            for(int i = 0; i < slotsArray.Length; i++)
            {
                if (slotsArray[i].isFree)
					saveString += Convert.ToString(GameInfo.i_emptySlotChar) + Convert.ToString(GameInfo.i_charItemSpacer);
                else
                    saveString += slotsArray[i].item.id + Convert.ToString(GameInfo.i_charItemSpacer);
            }

            return saveString;
        }

        public int getSizeOfInventory() { return slotsArray.Length; }

        public InventorySlot[] getSlotsArray()
        {
            return slotsArray;
        }
	}
}
