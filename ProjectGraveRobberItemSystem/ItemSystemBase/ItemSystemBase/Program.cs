﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemSystemBase.ItemSystem;

namespace ItemSystemBase
{
	class Program
	{
		static void Main(string[] args)
		{
			Item item = new Item("ItemNamePlaceHolder", 2);

			Console.WriteLine(item.name);
			Console.ReadLine();
		}
	}
}
