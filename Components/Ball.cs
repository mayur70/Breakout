using System;
using InputManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout.Components
{
    public class Ball : DrawableGameComponent
    {
        public float X;
        public float Y;
        public float Dx;
        public float Dy;
        float width;
        float height;
        public int Skin;
        SpriteBatch spriteBatch;
        public bool Active;

        public Rectangle BoundingBox { get { return new Rectangle((int)X, (int)Y, (int)width, (int)height); } }


        public Ball(Game game, SpriteBatch spriteBatch) : base(game)
        {
            Dx = 0;
            Dy = 0;
            width = 8;
            height = 8;
            this.Skin = 0;
            this.spriteBatch = spriteBatch;
            Active = false;
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(Constants.G_TEXTURE_MAIN, new Vector2(X, Y), Constants.G_FRAMES_BALLS[Skin], Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            base.Draw(gameTime);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            if (!Active)
                return;
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            X += Dx * delta;
            Y += Dy * delta;

            if (X <= 0)
            {
                X = 0;
                Dx = -Dx;
                Constants.G_SOUNDS_WALL_HIT.Play();
            }

            if (X >= Constants.VIRTUAL_WIDTH - width)
            {
                X = Constants.VIRTUAL_WIDTH - width;
                Dx = -Dx;
                Constants.G_SOUNDS_WALL_HIT.Play();
            }
            if (Y <= 0)
            {
                Y = 0;
                Dy = -Dy;
                Constants.G_SOUNDS_WALL_HIT.Play();
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public bool Collides(Rectangle target)
        {
            // if ((x > target.X + target.Width) || (target.X > (x + width)))
            //     return false;
            // if ((y > target.Y + target.Height) || (target.Y > (y + height)))
            //     return false;
            // return true;
            return new Rectangle((int)X, (int)Y, (int)width, (int)height).Intersects(target);
        }
    }
}