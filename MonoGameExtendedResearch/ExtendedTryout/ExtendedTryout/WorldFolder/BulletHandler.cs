using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTryout.WorldFolder
{
	class BulletHandler
	{
		private List<Bullet> bullets = new List<Bullet> { };

		private Texture2D bulletTex;

		public BulletHandler(ContentManager content)
		{
			bulletTex = content.Load<Texture2D>("Assets/Texture/red");
		}

		public void spawnBullet(Player player, bool direction)
		{
			float xOffset = direction ? GameSettings.bullet_offset_x_right: GameSettings.bullet_offset_x_left;

			Vector2 bulletSpawn = new Vector2(player.position.X + xOffset, player.position.Y + GameSettings.bullet_offset_y);

			Bullet newBullet = new Bullet(bulletTex, bulletSpawn, direction);
			bullets.Add(newBullet);
		}

		public void Update(GameTime gameTime)
		{
			foreach (Bullet bullet in new List<Bullet>(bullets))
				if (bullet.shouldBeRemoved)
					bullets.Remove(bullet);

			foreach (Bullet bullet in bullets)
				bullet.Update(gameTime);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			foreach (Bullet bullet in bullets)
				bullet.Draw(gameTime, spriteBatch);
		}

		public List<Bullet> getBulletList()
		{
			return bullets;
		}
	}
}
