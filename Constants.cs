using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Breakout
{
    public class Constants
    {

        public static readonly int VIRTUAL_WIDTH = 432;
        public static readonly int VIRTUAL_HEIGHT = 243;

        public static readonly int PADDLE_SPEED = 200;
        public static SpriteFont G_FONTS_SMALL;
        public static SpriteFont G_FONTS_MEDIUM;
        public static SpriteFont G_FONTS_LARGE;

        public static Texture2D G_TEXTURE_BACKGROUND;
        public static Texture2D G_TEXTURE_MAIN;
        public static Texture2D G_TEXTURE_ARROWS;
        public static Texture2D G_TEXTURE_HEARTS;
        public static Texture2D G_TEXTURE_PARTICLE;

        public static SoundEffect G_SOUNDS_PADDLE_HIT;
        public static SoundEffect G_SOUNDS_SCORE;
        public static SoundEffect G_SOUNDS_WALL_HIT;
        public static SoundEffect G_SOUNDS_CONFIRM;
        public static SoundEffect G_SOUNDS_SELECT;
        public static SoundEffect G_SOUNDS_NO_SELECT;
        public static SoundEffect G_SOUNDS_BRICK_HIT_1;
        public static SoundEffect G_SOUNDS_BRICK_HIT_2;
        public static SoundEffect G_SOUNDS_HURT;
        public static SoundEffect G_SOUNDS_VICTORY;
        public static SoundEffect G_SOUNDS_RECOVER;
        public static SoundEffect G_SOUNDS_HIGHT_SCORE;
        public static SoundEffect G_SOUNDS_PAUSE;
        public static Song G_SOUNDS_MUSIC;

        public static List<Rectangle> G_FRAMES_PADDLES;
        public static List<Rectangle> G_FRAMES_BALLS;
        public static List<Rectangle> G_FRAMES_BRICKS;
        public static List<Rectangle> G_FRAMES_HEARTS;

        public static void LoadContent(ContentManager content)
        {
            G_FONTS_SMALL = content.Load<SpriteFont>("fonts/small");
            G_FONTS_MEDIUM = content.Load<SpriteFont>("fonts/medium");
            G_FONTS_LARGE = content.Load<SpriteFont>("fonts/large");

            G_TEXTURE_BACKGROUND = content.Load<Texture2D>("graphics/background");
            G_TEXTURE_MAIN = content.Load<Texture2D>("graphics/breakout");
            G_TEXTURE_ARROWS = content.Load<Texture2D>("graphics/arrows");
            G_TEXTURE_HEARTS = content.Load<Texture2D>("graphics/hearts");
            G_TEXTURE_PARTICLE = content.Load<Texture2D>("graphics/particle");

            G_SOUNDS_PADDLE_HIT = content.Load<SoundEffect>("sounds/paddle_hit");
            G_SOUNDS_SCORE = content.Load<SoundEffect>("sounds/score");
            G_SOUNDS_WALL_HIT = content.Load<SoundEffect>("sounds/wall_hit");
            G_SOUNDS_CONFIRM = content.Load<SoundEffect>("sounds/confirm");
            G_SOUNDS_SELECT = content.Load<SoundEffect>("sounds/select");
            G_SOUNDS_NO_SELECT = content.Load<SoundEffect>("sounds/no-select");
            G_SOUNDS_BRICK_HIT_1 = content.Load<SoundEffect>("sounds/brick-hit-1");
            G_SOUNDS_BRICK_HIT_2 = content.Load<SoundEffect>("sounds/brick-hit-2");
            G_SOUNDS_HURT = content.Load<SoundEffect>("sounds/hurt");
            G_SOUNDS_VICTORY = content.Load<SoundEffect>("sounds/victory");
            G_SOUNDS_RECOVER = content.Load<SoundEffect>("sounds/recover");
            G_SOUNDS_HIGHT_SCORE = content.Load<SoundEffect>("sounds/high_score");
            G_SOUNDS_PAUSE = content.Load<SoundEffect>("sounds/pause");

            G_SOUNDS_MUSIC = content.Load<Song>("sounds/music");

            G_FRAMES_PADDLES = Utils.GenerateQuadsPaddles(G_TEXTURE_MAIN);
            G_FRAMES_BALLS = Utils.GenerateQuadsBalls(G_TEXTURE_MAIN);
            G_FRAMES_BRICKS = Utils.GenerateQuadsBricks(G_TEXTURE_MAIN);
            G_FRAMES_HEARTS = Utils.GenerateQuads(G_TEXTURE_HEARTS, 10, 9);
        }
    }
}