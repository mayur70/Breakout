using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    public class Utils
    {
        public static List<Rectangle> GenerateQuads(Texture2D atlas, int tileWidth, int tileHeight)
        {
            List<Rectangle> spriteSheet = new List<Rectangle>();
            int sheetWidth = atlas.Width / tileWidth;
            int sheetHeight = atlas.Height / tileHeight;
            for (int y = 0; y < sheetHeight; y++)
            {
                for (int x = 0; x < sheetWidth; x++)
                {
                    spriteSheet.Add(new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight));
                }
            }

            return spriteSheet;
        }

        public static List<Rectangle> SliceList(List<Rectangle> spriteSheet, int first, int last, int step)
        {
            List<Rectangle> slicedSpriteSheet = new List<Rectangle>();
            for (int i = first; i < last; i += step)
            {
                slicedSpriteSheet.Add(spriteSheet[i]);
            }
            return slicedSpriteSheet;
        }

        public static List<Rectangle> GenerateQuadsPaddles(Texture2D atlas)
        {
            int x = 0;
            int y = 64;

            List<Rectangle> quads = new List<Rectangle>();
            for (int i = 0; i <= 3; i++)
            {
                //smallest
                quads.Add(new Rectangle(x, y, 32, 16));
                //medium
                quads.Add(new Rectangle(x + 32, y, 64, 16));
                //large
                quads.Add(new Rectangle(x + 96, y, 96, 16));
                //huge
                quads.Add(new Rectangle(x, y + 16, 128, 16));

                y += 32;
            }

            return quads;
        }

        public static List<Rectangle> GenerateQuadsBalls(Texture2D atlas)
        {
            int x = 96;
            int y = 48;
            List<Rectangle> quads = new List<Rectangle>();
            for (int i = 0; i <= 3; i++)
            {
                quads.Add(new Rectangle(x, y, 8, 8));
                x += 8;
            }
            x = 96;
            y = 56;
            for (int i = 0; i <= 2; i++)
            {
                quads.Add(new Rectangle(x, y, 8, 8));
                x += 8;
            }
            return quads;
        }
    }
}