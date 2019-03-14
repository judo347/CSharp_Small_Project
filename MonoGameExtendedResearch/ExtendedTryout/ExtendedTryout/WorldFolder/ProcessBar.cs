using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ExtendedTryout.WorldFolder
{
	internal class ProcessBar
	{
		private Texture2D image_frame;
		private Texture2D image_process;
		private int status; //This keeps track of how much of the bar is full. 100 = 100%.
		public Vector2 position { get; set; }

		public Rectangle rectangleFrame
		{
			get
			{
				return new Rectangle((int)position.X, (int)position.Y, GameSettings.healthBar_width, GameSettings.healthBar_height); 
			}
		}
		public Rectangle rectangleProgress
		{
			set { }
			get
			{
				return new Rectangle((int)position.X, (int)position.Y, (int)(((double)rectangleFrame.Width / 100) * status), GameSettings.healthBar_height); 
			}
		}

		private ContentManager content;

		public ProcessBar(ContentManager content)
		{

			this.content = content;
			this.image_frame = content.Load<Texture2D>("Assets/Texture/red");
			this.image_process = content.Load<Texture2D>("Assets/Texture/green");
			this.status = 100;
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(image_frame, rectangleFrame, Color.Pink);
			spriteBatch.Draw(image_process, rectangleProgress, Color.Pink);
		}

		public void Update(GameTime gameTime, Vector2 pos, int health)
		{
			setStatus(health);
			updatePosition(pos);
		}

		/** Sets the status of the bar to the given percent. Parameter has to be within 0-100. */
		public void setStatus(int currentPercent)
		{
			if (currentPercent >= 0 && currentPercent <= 100)
				status = currentPercent;
		}

		public int getWidth()
		{
			return rectangleFrame.Width;
		}

		public int getHeight()
		{
			return rectangleFrame.Height;
		}

		public void updatePosition(Vector2 pos)
		{
			float correctPosX = pos.X + GameSettings.enemy_width / 2 - GameSettings.healthBar_width / 2;
			float correctPosY = pos.Y - 13;

			position = new Vector2(correctPosX, correctPosY);
		}
	}
}
