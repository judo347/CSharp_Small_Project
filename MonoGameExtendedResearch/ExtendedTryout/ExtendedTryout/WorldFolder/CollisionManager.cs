using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTryout.WorldFolder
{
	class CollisionManager
	{
		Rectangle ground;

		Player player;
		EnemyHandler enemyHandler;
		BulletHandler bulletHandler;

		SoundEffect sound_hurt;

		public CollisionManager(Rectangle ground, Player player, EnemyHandler enemyHandler, BulletHandler bulletHandler, SoundEffect hurt)
		{
			this.sound_hurt = hurt;
			this.ground = ground;
			this.player = player;
			this.enemyHandler = enemyHandler;
			this.bulletHandler = bulletHandler;
		}

		public void Update(GameTime gameTime)
		{
			foreach(Enemy enemy in enemyHandler.getEnemyList())
			{
				if (enemy.hitbox.Intersects(player.hitbox))
				{
					if(enemy.canAttack())
					{
						player.getHit(GameSettings.enemy_damagePerHit);
						enemy.hasAttacked();
					}
				}
				
			}

			foreach(Bullet bullet in bulletHandler.getBulletList())
			{
				foreach (Enemy enemy in enemyHandler.getEnemyList())
				{
					if (bullet.hitbox.Intersects(enemy.hitbox))
					{
						enemy.takeDamage(GameSettings.bullet_damage);
						sound_hurt.Play(0.05f, 0, 0);
						bullet.shouldBeRemoved = true;

						if (enemy.health <= 0)
							player.killCount++;
					}

				}
			}


		}
	}
}
