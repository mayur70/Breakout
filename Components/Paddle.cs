using System;
using InputManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout.Components
{
    public class Paddle : DrawableGameComponent
    {
        float x;
        float y;
        public float Dx;
        float width;
        float height;
        int skin;

        int size;
        SpriteBatch spriteBatch;

        public Rectangle BoundingBox { get { return new Rectangle((int)x, (int)y, (int)width, (int)height); } }


        public Paddle(Game game, SpriteBatch spriteBatch) : base(game)
        {
            x = Constants.VIRTUAL_WIDTH / 2 - 32;
            y = Constants.VIRTUAL_HEIGHT - 32;
            Dx = 0;
            width = 64;
            height = 16;
            skin = 0;
            size = 1;
            this.spriteBatch = spriteBatch;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(Constants.G_TEXTURE_MAIN, new Vector2(x, y), Constants.G_FRAMES_PADDLES[size + 4 * skin], Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            base.Draw(gameTime);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (InputHandler.IsKeyPressed(Keys.Left))
            {
                Dx = -Constants.PADDLE_SPEED;
            }
            else if (InputHandler.IsKeyPressed(Keys.Right))
            {
                Dx = Constants.PADDLE_SPEED;
            }
            else
            {
                Dx = 0;
            }

            if (Dx < 0)
            {
                x = MathHelper.Max(0, x + Dx * delta);
            }
            else
            {
                x = MathHelper.Min(Constants.VIRTUAL_WIDTH - width, x + Dx * delta);
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

    }
}