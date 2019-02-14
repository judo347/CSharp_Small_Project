using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemSystemBase.ItemSystem
{
	class Item
	{
		public String name { get; }
		public int id { get; }

		public Item(string name, int id)
		{
			this.name = name;
			this.id = id;
		}

		/** Returns a copy of this item. */
		public Item copy()
		{
			return new Item(this.name, this.id);
		}
	}
}
