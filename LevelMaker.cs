using System;
using System.Collections.Generic;
using Breakout.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class LevelMaker
    {
        public static int MAP_PATTERN_NONE = 1;
        public static int MAP_PATTERN_SINGLE_PYRAMID = 2;
        public static int MAP_PATTERN_MULTI_PYRAMID = 3;

        public static int ROW_PATTERN_SOLID = 1;
        public static int ROW_PATTERN_ALTERNATIVE = 2;
        public static int ROW_PATTERN_SKIP = 3;
        public static int ROW_PATTERN_NONE = 4;

        public static int level = 1;

        public static List<Brick> CreateMap(Game game, SpriteBatch spriteBatch, Random random)
        {
            List<Brick> bricks = new List<Brick>();

            int numRows = random.Next(1, 5);
            int numCols = random.Next(7, 13);
            numCols = numCols % 2 == 0 ? numCols + 1 : numCols;

            int highestTier = (int)Math.Min(3, Math.Floor((float)level / 5));

            int highestColor = Math.Min(5, level % 5 + 3);

            for (int y = 0; y < numRows; y++)
            {
                bool skipPattern = random.Next(2) == 0 ? true : false;
                bool alternatePattern = random.Next(2) == 0 ? true : false;

                int alternateColor1 = random.Next(1, highestColor);
                int alternateColor2 = random.Next(1, highestColor);
                int alternateTier1 = random.Next(0, highestTier);
                int alternateTier2 = random.Next(0, highestTier);

                bool skipFlag = random.Next(2) == 0 ? true : false;
                bool alternateFlag = random.Next(2) == 0 ? true : false;

                int solidColor = random.Next(1, highestColor);
                int solidTier = random.Next(0, highestTier);


                for (int x = 0; x < numCols; x++)
                {
                    if (skipPattern && skipFlag)
                    {
                        skipFlag = !skipFlag;
                        continue;
                    }
                    else
                    {
                        skipFlag = !skipFlag;
                    }
                    Brick brick = new Brick(game, (x * 32 + 8 + (13 - numCols) * 16), (y * 16) + 20, spriteBatch);

                    if(alternatePattern && alternateFlag)
                    {
                        brick.Color = alternateColor1;
                        brick.Tier = alternateTier1;
                        alternateFlag = !alternateFlag;
                    }
                    else
                    {
                        brick.Color = alternateColor2;
                        brick.Tier = alternateTier2;
                        alternateFlag = !alternateFlag;
                    }

                    if (!alternatePattern)
                    {
                        brick.Color = solidColor;
                        brick.Tier = solidTier;
                    }
                    bricks.Add(brick);
                }
            }

            if(bricks.Count == 0)
            {
                bricks = CreateMap(game, spriteBatch, random);
            }
            return bricks;
        }
    }
}