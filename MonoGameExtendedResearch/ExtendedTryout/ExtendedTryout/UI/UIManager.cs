using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
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
		RichParagraph rich1;
		RichParagraph rich2;

		public UIManager(ContentManager content)
		{
			this.content = content;
			UserInterface.Initialize(content, BuiltinThemes.hd);
			UserInterface.Active.ShowCursor = false;
			initialize();
		}

		private void initialize()
		{
			Panel panel = new Panel();
			panel.Anchor = Anchor.TopLeft;
			panel.MaxSize = new Vector2(220,110);

			rich1 = new RichParagraph();
			rich2 = new RichParagraph();

			panel.AddChild(rich1);
			panel.AddChild(rich2);

			UserInterface.Active.Root.AddChild(panel);

			/*
			ProgressBar progress = new ProgressBar(0, 100);
			progress.Value = 50;

			panel.AddChild(progress);*/

		}

		public void updateText(int kills, int hp)
		{
			rich1.Text = "Kills: " + kills.ToString();
			rich2.Text = "Health: " + hp.ToString();
		}
	}
}
