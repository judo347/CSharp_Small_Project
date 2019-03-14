using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Animations.SpriteSheets;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTryout.WorldFolder
{
	class Player
	{
		public Rectangle hitbox
		{
			get
			{
				return new Rectangle((int)position.X, (int)position.Y, width, height);
			}
		}

		//private Rectangle hitbox;
		private Texture2D tex;
		private int height = 80;
		private int width = 40;

		private int health = 100;
		private bool isDead = false;

		public bool canShoot = true;
		private double shootTimer = 0;

		public Vector2 position, velocity;

		public int killCount = 0;

		public bool playerFacing = false; //True = right
		private bool isWalking = false;

		//ANIMATION
		AnimatedSprite walkLegsRight;
		AnimatedSprite walkLegsLeft;
		AnimatedSprite idleTopRight;
		AnimatedSprite idleTopLeft;
		AnimatedSprite idleLegsRight;
		AnimatedSprite idleLegsLeft;
		AnimatedSprite shotTopRight;
		AnimatedSprite shotTopLeft;

		public Player(ContentManager content)
		{
			velocity = new Vector2(0, 0);
			position = new Vector2(GameSettings.player_startX - width / 2, GameSettings.player_startY - height);
			loadAssets(content);
		}

		private void loadAssets(ContentManager content)
		{
			tex = content.Load<Texture2D>("Assets/Texture/yellow");

			//Walking legs
			Texture2D texture = content.Load<Texture2D>("Assets/SpriteSheets/walkLegs");
			Dictionary<string, Rectangle> characterMap = content.Load<Dictionary<string, Rectangle>>("Assets/SpriteSheets/walkLegsMap");
			TextureAtlas atlas = new TextureAtlas("string", texture, characterMap);
			SpriteSheetAnimationFactory animationFactory = new SpriteSheetAnimationFactory(atlas);

			animationFactory.Add("string", new SpriteSheetAnimationData(new[] { 0, 1, 2, 3 }, isLooping: true, frameDuration: 0.2f));

			walkLegsRight = new AnimatedSprite(animationFactory, "string");
			walkLegsRight.Scale = new Vector2(1.4f, 1.4f);

			walkLegsLeft = new AnimatedSprite(animationFactory, "string");
			walkLegsLeft.Scale = new Vector2(1.4f, 1.4f);
			walkLegsLeft.Effect = SpriteEffects.FlipHorizontally;

			//Idle Legs
			Texture2D texture3 = content.Load<Texture2D>("Assets/SpriteSheets/idleLegs");
			Dictionary<string, Rectangle> characterMap3 = content.Load<Dictionary<string, Rectangle>>("Assets/SpriteSheets/idleLegsMap");
			TextureAtlas atlas3 = new TextureAtlas("string", texture3, characterMap3);
			SpriteSheetAnimationFactory animationFactory3 = new SpriteSheetAnimationFactory(atlas3);

			animationFactory3.Add("string", new SpriteSheetAnimationData(new[] { 0, 1, 2, 3 }, isLooping: true, frameDuration: 0.2f));

			idleLegsRight = new AnimatedSprite(animationFactory3, "string");
			idleLegsRight.Scale = new Vector2(1.4f, 1.4f);

			idleLegsLeft = new AnimatedSprite(animationFactory3, "string");
			idleLegsLeft.Scale = new Vector2(1.4f, 1.4f);
			idleLegsLeft.Effect = SpriteEffects.FlipHorizontally;

			//IdleTop
			Texture2D texture2 = content.Load<Texture2D>("Assets/SpriteSheets/walkTop");
			Dictionary<string, Rectangle> characterMap2 = content.Load<Dictionary<string, Rectangle>>("Assets/SpriteSheets/walkTopMap");
			TextureAtlas atlas2 = new TextureAtlas("string", texture2, characterMap2);
			SpriteSheetAnimationFactory animationFactory2 = new SpriteSheetAnimationFactory(atlas2);

			animationFactory2.Add("string", new SpriteSheetAnimationData(new[] { 0, 1, 2, 3 }, isLooping: true, frameDuration: 0.2f));

			idleTopRight = new AnimatedSprite(animationFactory2, "string");
			idleTopRight.Scale = new Vector2(1.4f, 1.4f);

			idleTopLeft = new AnimatedSprite(animationFactory2, "string");
			idleTopLeft.Scale = new Vector2(1.4f, 1.4f);
			idleTopLeft.Effect = SpriteEffects.FlipHorizontally;

			//Shooting top
			Texture2D texture4 = content.Load<Texture2D>("Assets/SpriteSheets/shoot");
			Dictionary<string, Rectangle> characterMap4 = content.Load<Dictionary<string, Rectangle>>("Assets/SpriteSheets/shootMap");
			TextureAtlas atlas4 = new TextureAtlas("string", texture4, characterMap4);
			SpriteSheetAnimationFactory animationFactory4 = new SpriteSheetAnimationFactory(atlas4);

			animationFactory4.Add("string", new SpriteSheetAnimationData(new[] { 0, 1, 2, 3 }, isLooping: true, frameDuration: 0.05f));

			shotTopRight = new AnimatedSprite(animationFactory4, "string");
			shotTopRight.Scale = new Vector2(1.4f, 1.4f);

			shotTopLeft = new AnimatedSprite(animationFactory4, "string");
			shotTopLeft.Scale = new Vector2(1.4f, 1.4f);
			shotTopLeft.Effect = SpriteEffects.FlipHorizontally;
		}

		public void Update(GameTime gameTime)
		{
			isWalking = false;

			if (!canShoot)
			{
				shootTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
				if(shootTimer > GameSettings.player_shootCooldown)
				{
					canShoot = true;
					shootTimer = 0;
				}
			}

			KeyboardState keyboardState = Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.D))
			{
				if(!(position.X + GameSettings.player_movementSpeed > GameSettings.g_screenwidth - width))
					position.X = position.X + GameSettings.player_movementSpeed;

				playerFacing = true;
				isWalking = true;
			}

			if (keyboardState.IsKeyDown(Keys.A))
			{
				if (!(position.X + GameSettings.player_movementSpeed < 0 + width / 2))
					position.X = position.X - GameSettings.player_movementSpeed;

				playerFacing = false;
				isWalking = true;
			}

			walkLegsRight.Update(gameTime);
			walkLegsRight.Position = new Vector2(position.X + hitbox.Width / 2, position.Y + 45 + 23);
			walkLegsLeft.Update(gameTime);
			walkLegsLeft.Position = new Vector2(position.X + hitbox.Width / 2, position.Y + 45 + 23);
			idleTopRight.Update(gameTime);
			idleTopRight.Position = new Vector2(position.X + hitbox.Width / 2, position.Y + 24);
			idleTopLeft.Update(gameTime);
			idleTopLeft.Position = new Vector2(position.X + hitbox.Width / 2, position.Y + 24);
			idleLegsRight.Update(gameTime);
			idleLegsRight.Position = new Vector2(position.X + hitbox.Width / 2, position.Y + 45 + 23);
			idleLegsLeft.Update(gameTime);
			idleLegsLeft.Position = new Vector2(position.X + hitbox.Width / 2, position.Y + 45 + 23);
			shotTopLeft.Update(gameTime);
			shotTopLeft.Position = new Vector2(position.X + hitbox.Width / 2, position.Y + 24);
			shotTopRight.Update(gameTime);
			shotTopRight.Position = new Vector2(position.X + hitbox.Width / 2, position.Y + 24);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//if(!isDead)
			//	spriteBatch.Draw(tex, hitbox, Color.White);

			//TOP ANIMATION
			if (Keyboard.GetState().IsKeyDown(Keys.Right))
				shotTopRight.Draw(spriteBatch);
			else if(Keyboard.GetState().IsKeyDown(Keys.Left))
				shotTopLeft.Draw(spriteBatch);
			else if (playerFacing)
				idleTopRight.Draw(spriteBatch);
			else
				idleTopLeft.Draw(spriteBatch);

			//LEG ANIMATION
			if (Keyboard.GetState().IsKeyDown(Keys.D))
				walkLegsRight.Draw(spriteBatch);
			else if (Keyboard.GetState().IsKeyDown(Keys.A))
				walkLegsLeft.Draw(spriteBatch);
			else if (playerFacing)
				idleLegsRight.Draw(spriteBatch);
			else
				idleLegsLeft.Draw(spriteBatch);
		}

		public void getHit(int damage)
		{
			if(health > 0)
				this.health -= damage;

			if(health <= 0)
			{
				isDead = true;
			}
		}

		public int getHealth()
		{
			return health;
		}
	}
}
