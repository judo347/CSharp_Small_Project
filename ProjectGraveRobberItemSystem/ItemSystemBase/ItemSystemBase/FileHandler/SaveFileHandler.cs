using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public Item[] loadAllItems()
		{
			return null; //TODO TODO
		}


	}
}
