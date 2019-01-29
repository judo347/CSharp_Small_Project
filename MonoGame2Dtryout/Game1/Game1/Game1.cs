using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		Texture2D background;
		Texture2D ship;
		Texture2D shot;

		Vector2 shipPosition;
		Vector2 shotPosition;
		Vector2 shotOffset;
		bool hasShot = false;

		SpriteFont font;

		SoundEffect shootingSound;

		Song backgroundMusic;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
			// TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			ship = Content.Load<Texture2D>("blueship1"); //Loads the texture from the asset manager. 
			background = Content.Load<Texture2D>("background");
			shot = Content.Load<Texture2D>("shot");

			shotOffset = new Vector2(ship.Width, ship.Height/2); //THIS IS IMPORTANT!

			font = Content.Load<SpriteFont>("defaultFont");

			shootingSound = Content.Load<SoundEffect>("shotSound");

			backgroundMusic = Content.Load<Song>("theme");
			MediaPlayer.Play(backgroundMusic);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here
			Vector2 movement = Vector2.Zero; //We will take changes through input and apply it to this movement vector, and then apply that to the position vector. To avoid issues.
			KeyboardState keyState = Keyboard.GetState(); //We should also capture the state for the last update and compare to see if new keys has been pressed.

			if (keyState.IsKeyDown(Keys.Right))
			{
				movement.X += 2;
			}
			if (keyState.IsKeyDown(Keys.Left))
			{
				movement.X -= 2;
			}
			if (keyState.IsKeyDown(Keys.Up))
			{
				movement.Y -= 2;
			}
			if (keyState.IsKeyDown(Keys.Down))
			{
				movement.Y += 2;
			}
			if (keyState.IsKeyDown(Keys.Space) && !hasShot)
			{
				shotPosition = shipPosition + shotOffset;
				hasShot = true;
				shootingSound.Play();
				//Draw shot
			}

			//Check gamepad
			//Check touch

			shipPosition += movement; //Apply the changes to the ships pos.

			if (hasShot)
			{
				shotPosition.X += 5;
				if (shotPosition.X > GraphicsDevice.Viewport.Width)
				{
					hasShot = false;
				}
			}

			base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(background, Vector2.Zero, Color.White);
			spriteBatch.Draw(ship, shipPosition, Color.White);
			spriteBatch.DrawString(font, "Hello ME!", Vector2.Zero, Color.Yellow);
			if (hasShot) spriteBatch.Draw(shot, shotPosition, Color.White);
			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
