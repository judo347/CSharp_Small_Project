using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemSystemBase.FileHandler;
using ItemSystemBase.ItemSystem;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ItemSystemBaseTests")] //This does that the solution ItemSystemBaseTests can see all files in this namespace
namespace ItemSystemBase
{
	class Program
	{
		static void Main(string[] args)
		{
            SaveFileHandler saveFileHandler = new SaveFileHandler(new AssetManager());

            Item[] allItems = saveFileHandler.loadAllItems();
			Console.ReadLine();
		}
	}
}
