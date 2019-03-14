using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.Sprites;

namespace ExtendedTryout.WorldFolder
{
	class Enemy
	{
		public Rectangle hitbox
		{
			get
			{
				return new Rectangle((int)position.X, (int)position.Y, width, height);
			}
		}

		private Texture2D tex;
		private AnimatedSprite animation;
		private int height = GameSettings.enemy_height;
		private int width = GameSettings.enemy_width;
		private Vector2 position;

		private bool hasJustAttacked = false;
		private double attackTimer = 0;
		public bool shouldBeRemoved = false;

		public int health = GameSettings.enemy_health;
		private bool direction; //True = right

		private ProcessBar hpBar;

		public Enemy(AnimatedSprite anim, Texture2D tex, Vector2 pos, bool direction, ContentManager content)
		{

			anim.Scale = new Vector2(1.4f, 1.4f) ;
			if (!direction)
				anim.Effect = SpriteEffects.FlipHorizontally;
			animation = anim;
			position = pos;
			this.tex = tex;
			this.direction = direction;

			hpBar = new ProcessBar(content);
		}

		public void Update(GameTime gameTime)
		{
			attackTimer += gameTime.ElapsedGameTime.TotalMilliseconds;

			if (attackTimer > GameSettings.enemy_attackCooldown)
			{
				hasJustAttacked = false;
				attackTimer = 0;
			}

			if(direction)
				position.X += GameSettings.enemy_movementSpeed;
			else
				position.X -= GameSettings.enemy_movementSpeed;

			hpBar.Update(gameTime, position, health);

			animation.Update(gameTime);
			animation.Position = new Vector2(position.X + GameSettings.enemy_width /2, position.Y + GameSettings.enemy_height / 2);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//spriteBatch.Draw(tex, hitbox, Color.Pink); //DRAW HITBOX
			hpBar.Draw(gameTime, spriteBatch);
			//spriteBatch.End();
			//hpBar.Draw(spriteBatch);
			//spriteBatch.Begin();

			//spriteBatch.Draw(animation, hitbox, Color.Pink);
			animation.Draw(spriteBatch);
		}

		public void hasAttacked()
		{
			hasJustAttacked = true;
		}

		public bool canAttack()
		{
			return !hasJustAttacked;
		}

		public void takeDamage(int damage)
		{
			health -= damage;
			if (health <= 0)
				this.shouldBeRemoved = true;
		}
	}
}
