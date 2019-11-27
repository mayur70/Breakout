using System;
using System.Collections.Generic;
using Breakout.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class LevelMaker
    {
        public static List<Brick> CreateMap(Game game, SpriteBatch spriteBatch, Random random)
        {
            List<Brick> bricks = new List<Brick>();

            int numRows = random.Next(1, 5);
            int numCols = random.Next(7, 13);

            for (int y = 0; y < numRows; y++)
            {
                for (int x = 0; x < numCols; x++)
                {
                    Brick brick = new Brick(game, (x * 32 + 8 + (13 - numCols) * 16), (y * 16) + 20, spriteBatch);
                    bricks.Add(brick);
                }
            }

            return bricks;
        }
    }
}