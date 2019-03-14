using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedTryout
{
	class GameSettings
	{
		public static int g_screenwidth = 1280;
		public static int g_screenheight = 720;

		public static int mob_ground_space = -30;

		public static int ground_height = 80;
		public static int ground_min_spawn_y = g_screenheight - ground_height - mob_ground_space;

		public static int player_startX = g_screenwidth / 2;
		public static int player_startY = ground_min_spawn_y;
		public static int player_movementSpeed = 7;
		public static int player_shootCooldown = 150; //miliseconds
		//public static int player_shootCooldown = 2000; //miliseconds

		public static int enemy_height = 80;
		public static int enemy_width = 40;
		public static Vector2 enemySpawnLeft = new Vector2(0, ground_min_spawn_y - enemy_height);
		public static Vector2 enemySpawnRight = new Vector2(g_screenwidth - enemy_width, ground_min_spawn_y - enemy_height);
		public static int enemy_spawnInterval = 1000; //miliseconds
		public static int enemy_damagePerHit = 5;
		public static int enemy_attackCooldown = 1000; //miliseconds
		public static int enemy_movementSpeed = 3;
		public static int enemy_health = 100;

		public static int bullet_height = 2;
		public static int bullet_width = 5;
		public static int bullet_damage = 30;
		public static int bullet_movementSpeed = 20;
		public static int bullet_offset_y = 33;
		public static int bullet_offset_x_right = 70;
		public static int bullet_offset_x_left = -35;

		public static int healthBar_height = 5;
		public static int healthBar_width = enemy_width + 10;
	}
}
