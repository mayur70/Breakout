using System;
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
            Components.Add(paddle);
            Components.Add(ball);
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
                ball.Y = paddle.BoundingBox.Y - ball.BoundingBox.Height - 1;
                ball.Dy = -ball.Dy;
                Constants.G_SOUNDS_PADDLE_HIT.Play();
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
