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
        float dx;
        float width;
        float height;
        int skin;

        int size;
        SpriteBatch spriteBatch;


        public Paddle(Game game, SpriteBatch spriteBatch) : base(game)
        {
            x = Constants.VIRTUAL_WIDTH / 2 - 32;
            y = Constants.VIRTUAL_HEIGHT - 32;
            dx = 0;
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
                dx = -Constants.PADDLE_SPEED;
            }
            else if (InputHandler.IsKeyPressed(Keys.Right))
            {
                dx = Constants.PADDLE_SPEED;
            }
            else
            {
                dx = 0;
            }

            if (dx < 0)
            {
                x = MathHelper.Max(0, x + dx * delta);
            }
            else
            {
                x = MathHelper.Min(Constants.VIRTUAL_WIDTH - width, x + dx * delta);
            }
            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

    }
}