using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemSystemBase
{
    class AssetManager
    {

        private static String current_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        public static String allItemsFilePath = current_path + "\\" + "FileHandler\\Files\\allItems.xml"; //TODO
		public static String saveFilePath = current_path + "\\" + "FileHandler\\Files\\saveFile.txt"; //TODO


		public String getAllItemsFilePath()
        {
            return allItemsFilePath;
        }

		public String getSaveFilePath()
		{
			return saveFilePath;
		}
	}
}
