using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTryout.WorldFolder
{
	class Bullet
	{
		public Rectangle hitbox
		{
			get
			{
				return new Rectangle((int)position.X, (int)position.Y, width, height);
			}
		}

		private Texture2D tex;
		private int height = GameSettings.bullet_height;
		private int width = GameSettings.bullet_width;
		private Vector2 position;

		public bool shouldBeRemoved = false;

		private bool direction; //True = right

		public Bullet(Texture2D tex, Vector2 pos, bool direction)
		{
			position = pos;
			this.tex = tex;
			this.direction = direction;
		}

		public void Update(GameTime gameTime)
		{
			if (direction)
				position.X += GameSettings.bullet_movementSpeed;
			else
				position.X -= GameSettings.bullet_movementSpeed;
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(tex, hitbox, Color.Pink);
		}
	}
}
