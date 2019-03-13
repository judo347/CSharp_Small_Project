using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTryout.UI
{
	class UIManager
	{
		ContentManager content;
		Panel inventory = new Panel();
		bool inventoryActive = false;
		//Panel basePanel = new Panel();

		public UIManager(ContentManager content)
		{
			this.content = content;
			UserInterface.Initialize(content, BuiltinThemes.hd);

			initialize();
		}

		private void initialize()
		{
			Panel panel = new Panel();
			panel.Anchor = Anchor.CenterLeft;
			//GeonBit.UI.Entities.
			panel.AddChild(new Button("Always there"));

			UserInterface.Active.Root.AddChild(panel);

			inventory.Anchor = Anchor.CenterRight;
			Button invButton = new Button("Base ui");
			inventory.AddChild(invButton);
		}

		public void toggleInventory()
		{
			if (inventoryActive)
			{
				UserInterface.Active.Root.RemoveChild(inventory);
			}
			else
				UserInterface.Active.Root.AddChild(inventory);
		}

	}
}
