using System.Collections.Generic;
using Breakout;
using Breakout.Components;
using InputManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StateManager;

namespace GameStates
{
    public interface IServeState : IGameState
    {

    }

    public class ServeStateParameters
    {
        public Paddle Paddle;
        public List<Brick> Bricks;
        public int Health;
        public int Score;

        public ServeStateParameters(Paddle paddle, List<Brick> bricks, int health, int score)
        {
            this.Paddle = paddle;
            this.Bricks = bricks;
            this.Health = health;
            this.Score = score;
        }
    }
    public class ServeState : BaseGameState, IServeState
    {

        int highlighted;
        Color hightlightedColor;

        Ball ball;
        Paddle paddle;
        int health;
        int score;
        List<Brick> bricks;

        public ServeState(Game game, Paddle paddle, int health, int score, List<Brick> bricks) : base(game)
        {
            // game.Services.AddService(typeof(IServeState), this);
            hightlightedColor = new Color(103, 255, 255);
            highlighted = 0;
            this.paddle = paddle;
            this.health = health;
            this.score = score;
            this.bricks = bricks;
            ball = new Ball(this.Game, GameRef.SpriteBatch);
            ball.Skin = random.Next(7);

            foreach (Brick brick in bricks)
            {
                Components.Add(brick);
            }

            Components.Add(paddle);
            Components.Add(ball);
        }

        protected override void LoadContent()
        {

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.IsKeyJustPressed(Keys.Enter))
            {
                PlayState playState = new PlayState(this.Game, paddle, ball, health, score, bricks);

                foreach (Brick brick in bricks)
                {
                    Components.Remove(brick);
                }
                Components.Remove(paddle);
                Components.Remove(ball);
                manager.ChangeState(playState);
            }

            if (InputHandler.IsKeyJustPressed(Keys.Escape))
            {
                Game.Exit();
            }

            base.Update(gameTime);

            ball.X = paddle.BoundingBox.X + (paddle.BoundingBox.Width / 2) - 4;
            ball.Y = paddle.BoundingBox.Y - 8;
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.RenderHealth(GameRef.SpriteBatch, health);
            GameRef.RenderScore(GameRef.SpriteBatch, score);
            string title = "Press Enter to serve!";
            Vector2 msgSize = Constants.G_FONTS_MEDIUM.MeasureString(title);
            GameRef.SpriteBatch.DrawString(Constants.G_FONTS_MEDIUM, title,
                new Vector2((Constants.VIRTUAL_WIDTH / 2) - (msgSize.X / 2), Constants.VIRTUAL_HEIGHT / 2), Color.White);

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}