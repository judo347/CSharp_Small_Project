using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTryout.WorldFolder
{
	class World
	{
		private Rectangle ground;
		private Texture2D groundTex;
		private Rectangle background;
		private Texture2D backgroundTex;
		private int groundHeight = GameSettings.ground_height;

		//const float gravity = 100f;

		private Player player;
		private EnemyHandler enemyHandler;
		private CollisionManager collisionManager;
		private BulletHandler bulletHandler;

		//Sound
		SoundEffect sound_shot;

		public World(GraphicsDevice gd, ContentManager content)
		{
			ground = new Rectangle(0, GameSettings.g_screenheight - groundHeight, GameSettings.g_screenwidth, groundHeight);
			groundTex = content.Load<Texture2D>("Assets/Texture/ground");

			background = new Rectangle(0, 0, GameSettings.g_screenwidth, GameSettings.g_screenheight);
			backgroundTex = content.Load<Texture2D>("Assets/Texture/background");

			sound_shot = content.Load<SoundEffect>("Assets/Sound/shoot");
			SoundEffect hurt = content.Load<SoundEffect>("Assets/Sound/hurt");

			player = new Player(content);
			enemyHandler = new EnemyHandler(content);

			bulletHandler = new BulletHandler(content);
			collisionManager = new CollisionManager(ground, player, enemyHandler, bulletHandler, hurt);
		}

		public void Update(GameTime gameTime)
		{
			player.Update(gameTime);
			enemyHandler.Update(gameTime);
			collisionManager.Update(gameTime);
			bulletHandler.Update(gameTime);

			KeyboardState keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.Left))
			{
				if (player.canShoot)
				{
					bulletHandler.spawnBullet(player, false);
					sound_shot.Play(0.05f, 0, 0);
					player.canShoot = false;
				}
				
			}

			if (keyboardState.IsKeyDown(Keys.Right))
			{
				if (player.canShoot)
				{
					bulletHandler.spawnBullet(player, true);
					sound_shot.Play(0.05f, 0, 0);
					player.canShoot = false;
				}
			}
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(backgroundTex, background, Color.White);

			player.Draw(gameTime, spriteBatch);
			enemyHandler.Draw(gameTime, spriteBatch);
			bulletHandler.Draw(gameTime, spriteBatch);

			spriteBatch.Draw(groundTex, ground, Color.White);
		}

		public int getPlayerKills()
		{
			return player.killCount;
		}

		public int getPlayerHealth()
		{
			return player.getHealth();
		}
	}
}
