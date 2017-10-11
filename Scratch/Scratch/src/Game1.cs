﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Scratch {

	public class Game1 : Game {

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		private Enemy zombie;
		private Player player;

		static int squaresAcross = 32;
		static int squaresDown = 32;
		TileMap myMap = new TileMap(squaresDown, squaresAcross);

		public Game1() {
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		protected override void Initialize() {
			//TODO: Add your initialization logic here
			base.Initialize();
		}

		protected override void LoadContent() {
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Texture2D zombieTexture = Content.Load<Texture2D>("zombie_0");
			Texture2D playerTexture = Content.Load<Texture2D>("player");
			Tile.TileSetTexture = Content.Load<Texture2D>(@"MapSprite");
			zombie = new Enemy(zombieTexture, 8, 36, 50, 5, 90);
			player = new Player(playerTexture, 4, 4);
			player.initialize();
			zombie.initialize();
		}

		protected override void Update( GameTime gameTime ) {
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			// TODO: Add your update logic here
			if (IsActive) {
				player.Update(gameTime);
				zombie.Update(gameTime, player.pos);
				base.Update(gameTime);
				myMap.Update(gameTime);
			}
		}

		protected override void Draw( GameTime gameTime ) {
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			//TODO: Add your drawing code here
			myMap.Draw(spriteBatch);
			zombie.Draw(spriteBatch, zombie.ePos);
			player.Draw(spriteBatch, player.pos);
			base.Draw(gameTime);
		}
	}
}
