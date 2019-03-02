using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace ShipGame
{
    class OuterTile : Tile
    {
        public bool IsRevealed { get; set; }
        public readonly Texture2D Sprite;
        public readonly float SpriteScale;
        public int MapX { get; set; }
        public int MapY { get; set; }


        public OuterTile(int x, int y, bool isRevealed, Texture2D texture, float spriteScale) : base(x,y)
        {
            this.Sprite = texture;
            this.SpriteScale = spriteScale;

            //Initial x position
            int xStart = (int)((x * this.Sprite.Width * this.SpriteScale));

            //Offsets xStart based on y position to help stagger tiles diagonally
            int xOffset = (int)((y * this.Sprite.Width * this.SpriteScale));

            //used to help center grid in window
            int xWindowGutter = (Game1.graphics.PreferredBackBufferWidth - (int)(this.Sprite.Width * this.SpriteScale * 1.85f) * GameManager.NUM_TILES) / 2;


            //Combines all x position information to get the x map position
            this.MapX = xStart + xOffset + xWindowGutter;

            //starts y position at half height of the window
            int yStart = (Game1.graphics.PreferredBackBufferHeight / 2) - (int)((this.Sprite.Height / 2) * this.SpriteScale);

            //offsets the y value based off of x position
            int yOffset = (int)((y * this.Sprite.Height * this.SpriteScale) - (x * this.Sprite.Height * this.SpriteScale));
            
            //Combines all y position information to get the y map position
            this.MapY = yStart - yOffset;

            this.IsRevealed = isRevealed;
        }
    }

    class InnerTile : Tile
    {
        public Texture2D sprite { get; set; }

        public InnerTile(int x, int y, Texture2D texture) : base(x, y)
        {
            sprite = texture;
        }
    }

    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Tile(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
