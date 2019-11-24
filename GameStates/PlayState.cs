using System;
using System.Collections.Generic;
using Breakout;
using Breakout.Components;
using InputManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StateManager;

namespace GameStates
{
    public interface IPlayState : IGameState
    {

    }
    public class PlayState : BaseGameState, IPlayState
    {

        Paddle paddle;
        Ball ball;

        List<Brick> bricks;
        bool paused;
        public PlayState(Game game) : base(game)
        {
            // game.Services.AddService(typeof(IPlayState), this);
            paused = false;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            paddle = new Paddle(this.Game, GameRef.SpriteBatch);
            ball = new Ball(this.Game, 0, GameRef.SpriteBatch);
            ball.Dx = random.Next(-200, 200);
            ball.Dy = random.Next(-60, -50);
            ball.X = Constants.VIRTUAL_WIDTH / 2 - 4;
            ball.Y = Constants.VIRTUAL_HEIGHT - 42;

            bricks = LevelMaker.CreateMap(this.Game, GameRef.SpriteBatch, random);

            Components.Add(paddle);
            Components.Add(ball);

            foreach (Brick brick in bricks)
            {
                Components.Add(brick);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (paused)
            {
                if (InputHandler.IsKeyJustPressed(Keys.Space))
                {
                    paused = false;
                    Constants.G_SOUNDS_PAUSE.Play();
                }
                else
                {
                    return;
                }
            }
            else if (InputHandler.IsKeyJustPressed(Keys.Space))
            {
                paused = true;
                Constants.G_SOUNDS_PAUSE.Play();
            }

            base.Update(gameTime);

            if (ball.Collides(paddle.BoundingBox))
            {
                ball.Y = paddle.BoundingBox.Y - ball.BoundingBox.Height;
                ball.Dy = -ball.Dy;

                if (ball.X < paddle.BoundingBox.X + (paddle.BoundingBox.Width / 2) && paddle.Dx < 0)
                {
                    ball.Dx = -50 + -(8 * (paddle.BoundingBox.X + paddle.BoundingBox.Width / 2 - ball.X));
                }
                else if (ball.X > paddle.BoundingBox.X + (paddle.BoundingBox.Width / 2) && paddle.Dx > 0)
                {
                    ball.Dx = 50 + (8 * Math.Abs(paddle.BoundingBox.X + paddle.BoundingBox.Width / 2 - ball.X));
                }
                Constants.G_SOUNDS_PADDLE_HIT.Play();
            }

            foreach (Brick brick in bricks)
            {
                if (brick.InPlay && ball.Collides(brick.BoundingBox))
                {
                    brick.Hit();

                    if (ball.X + 2 < brick.BoundingBox.X && ball.Dx > 0)
                    {
                        ball.Dx = -ball.Dx;
                        ball.X = brick.BoundingBox.X - 8;
                    }
                    else if (ball.X + 6 > brick.BoundingBox.X + brick.BoundingBox.Width && ball.Dx < 0)
                    {
                        ball.Dx = -ball.Dx;
                        ball.X = brick.BoundingBox.X + 32;
                    }
                    else if (ball.Y < brick.BoundingBox.Y)
                    {
                        ball.Dy = -ball.Dy;
                        ball.Y = brick.BoundingBox.Y - 8;
                    }
                    else
                    {
                        ball.Dy = -ball.Dy;
                        ball.Y = brick.BoundingBox.Y + 16;
                    }
                    ball.Dy = ball.Dy * 1.02f;
                }
            }

            if (InputHandler.IsKeyJustPressed(Keys.Escape))
            {
                Game.Exit();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (paused)
            {
                string pausedMsg = "PAUSED";
                Vector2 msgSize = Constants.G_FONTS_LARGE.MeasureString(pausedMsg);
                GameRef.SpriteBatch.DrawString(Constants.G_FONTS_LARGE, pausedMsg, new Vector2(Constants.VIRTUAL_WIDTH / 2 - msgSize.X / 2, Constants.VIRTUAL_HEIGHT / 2 - 16), Color.White);
            }
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}
