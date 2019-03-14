using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Animations.SpriteSheets;
using MonoGame.Extended.TextureAtlases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTryout.WorldFolder
{
	class EnemyHandler
	{
		List<Enemy> enemies = new List<Enemy> { };

		private Texture2D enemyTex;
		private SpriteSheetAnimationFactory zombieAnimationFactory;
		private bool lastSideSpawn = true;

		private double spawnTimer = 0;

		private ContentManager content;

		public EnemyHandler(ContentManager content)
		{
			this.content = content;
			enemyTex = content.Load<Texture2D>("Assets/Texture/blue");
			loadSpriteSheet(content);
		}

		private void loadSpriteSheet(ContentManager content)
		{
			Texture2D enemyTexture = content.Load<Texture2D>("Assets/SpriteSheets/Zombie");
			Dictionary<string, Rectangle> characterMap = content.Load<Dictionary<string, Rectangle>>("Assets/SpriteSheets/ZombieMap");
			TextureAtlas zombieAtlas = new TextureAtlas("zombie", enemyTexture, characterMap);
			SpriteSheetAnimationFactory zombieAnimationFactory = new SpriteSheetAnimationFactory(zombieAtlas);

			zombieAnimationFactory.Add("walking", new SpriteSheetAnimationData(new[] { 0, 1, 2, 3 }, isLooping: true, frameDuration: 0.2f));

			this.zombieAnimationFactory = zombieAnimationFactory;

			//AnimatedSprite characterSpriteAnimation = new AnimatedSprite(zombieAnimationFactory, "walking");
			//anim = characterSpriteAnimation;
		}

		public void spawnEnemy()
		{
			Enemy newEnemy = new Enemy(new AnimatedSprite(zombieAnimationFactory, "walking"), enemyTex, lastSideSpawn ? GameSettings.enemySpawnLeft : GameSettings.enemySpawnRight, lastSideSpawn ? true : false, content);
			lastSideSpawn = !lastSideSpawn;
			enemies.Add(newEnemy);
		}

		public void Update(GameTime gameTime)
		{
			spawnTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

			foreach (Enemy enemy in new List<Enemy>(enemies))
				if (enemy.shouldBeRemoved)
					enemies.Remove(enemy);

			if (spawnTimer > GameSettings.enemy_spawnInterval)
			{
				spawnEnemy();
				spawnTimer = 0;
			}

			foreach (Enemy enemy in enemies)
				enemy.Update(gameTime);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			foreach (Enemy enemy in enemies)
				enemy.Draw(gameTime, spriteBatch);
		}

		public List<Enemy> getEnemyList()
		{
			return enemies;
		}
	}
}
