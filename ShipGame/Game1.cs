using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ShipGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        //List<OuterTile> OuterTiles;

        OuterTile[,] OuterTiles;

        List<InnerTile> InnerTiles;
        Dictionary<string,Texture2D> TileTextures;

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
            graphics.PreferredBackBufferWidth = 1200;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();

            OuterTiles = new OuterTile[GameManager.NUM_TILES, GameManager.NUM_TILES];

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
            TileTextures = new Dictionary<string, Texture2D>()
            {
                { "tile", Content.Load<Texture2D>("Tile") }
            };

            font = Content.Load<SpriteFont>("DefaultFont");


            //OuterTiles = new List<OuterTile>();

            for(var i = 0; i < GameManager.NUM_TILES; i++)
            {
                for(var j = 0; j < GameManager.NUM_TILES; j++)
                {
                    OuterTiles[i,j] = new OuterTile(i, j, true, TileTextures["tile"], 1.5f /  GameManager.NUM_TILES);
                }
            }

            InnerTiles = new List<InnerTile>()
            {

            };



            // TODO: use this.Content to load your game content here
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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            for(var i = 0; i < GameManager.NUM_TILES; i++)
            {
                for(var j = 0; j < GameManager.NUM_TILES; j++)
                {
                    //draw sprites
                    spriteBatch.Draw(OuterTiles[i,j].Sprite, new Vector2(OuterTiles[i, j].MapX, OuterTiles[i,j].MapY), null, Color.White, 0f, Vector2.Zero, OuterTiles[i,j].SpriteScale, SpriteEffects.None, 0f);

                    //Draw text
                    spriteBatch.DrawString(font, "X: " + OuterTiles[i, j].X.ToString() + "\n" +
                                                 "Y: " + OuterTiles[i, j].Y.ToString() + "\n" +
                                                 "MapX: " + OuterTiles[i, j].MapX.ToString() + "\n" +
                                                 "MapY: " + OuterTiles[i, j].MapY.ToString(),
                                                 new Vector2(OuterTiles[i, j].MapX, OuterTiles[i, j].MapY -                                     (TileTextures["tile"].Height/2) * OuterTiles[i,j].SpriteScale),
                                                 Color.White);

                }
            }

//            foreach(OuterTile o in OuterTiles)
//            {
//                spriteBatch.Draw(o.sprite, new Vector2((o.X * o.sprite.Width/2) + (o.Y * o.sprite.Width/8) + (10 * o.X),(o.Y * o.sprite.Height/8) + (10 * o.Y)), null, Color.White, 0f,
//Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
//            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
