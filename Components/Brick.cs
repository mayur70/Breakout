using System;
using InputManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Breakout.Components
{
    public class Brick : DrawableGameComponent
    {
        float x;
        float y;
        float width;
        float height;
        public int Color;
        public int Tier;
        public bool InPlay;
        SpriteBatch spriteBatch;

        public Rectangle BoundingBox { get { return new Rectangle((int)x, (int)y, (int)width, (int)height); } }


        public Brick(Game game, int x, int y, SpriteBatch spriteBatch) : base(game)
        {
            this.x = x;
            this.y = y;
            width = 32;
            height = 16;
            Color = 0;
            Tier = 0;
            InPlay = true;
            this.spriteBatch = spriteBatch;
        }

        public override void Draw(GameTime gameTime)
        {
            if (InPlay)
            {
                spriteBatch.Draw(Constants.G_TEXTURE_MAIN,
                    new Vector2(x, y),
                    Constants.G_FRAMES_BRICKS[(Color * 4) + Tier],
                    Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            }
            base.Draw(gameTime);
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public void Hit()
        {
            Constants.G_SOUNDS_BRICK_HIT_2.Play();
            InPlay = false;
        }

    }
}