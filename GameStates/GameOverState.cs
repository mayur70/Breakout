using System.Collections.Generic;
using Breakout;
using Breakout.Components;
using InputManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StateManager;

namespace GameStates
{
    public interface IGameOverState : IGameState
    {

    }
    public class GameOverState : BaseGameState, IGameOverState
    {

        int highlighted;
        Color hightlightedColor;
        int score;
        public GameOverState(Game game, int score) : base(game)
        {
            // game.Services.AddService(typeof(IStartState), this);
            hightlightedColor = new Color(103, 255, 255);
            highlighted = 0;
            this.score = score;
        }

        protected override void LoadContent()
        {

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            if (InputHandler.IsKeyJustPressed(Keys.Enter))
            {
                manager.ChangeState(new StartState(this.Game));
            }

            if (InputHandler.IsKeyJustPressed(Keys.Escape))
            {
                Game.Exit();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            string gameOverMsg = "GAME OVER";
            Vector2 msgSize = Constants.G_FONTS_LARGE.MeasureString(gameOverMsg);
            GameRef.SpriteBatch.DrawString(Constants.G_FONTS_LARGE, gameOverMsg,
                new Vector2((Constants.VIRTUAL_WIDTH / 2) - (msgSize.X / 2), Constants.VIRTUAL_HEIGHT / 3), Color.White);

            string finalScoreMsg = "Final Score: " + score.ToString();
            msgSize = Constants.G_FONTS_MEDIUM.MeasureString(finalScoreMsg);
            GameRef.SpriteBatch.DrawString(Constants.G_FONTS_MEDIUM, finalScoreMsg,
                new Vector2((Constants.VIRTUAL_WIDTH / 2) - (msgSize.X / 2), Constants.VIRTUAL_HEIGHT / 2), Color.White);

            string continueMsg = "Press Enter!";
            msgSize = Constants.G_FONTS_MEDIUM.MeasureString(continueMsg);
            GameRef.SpriteBatch.DrawString(Constants.G_FONTS_MEDIUM, continueMsg,
                new Vector2((Constants.VIRTUAL_WIDTH / 2) - (msgSize.X / 2),
                 Constants.VIRTUAL_HEIGHT - Constants.VIRTUAL_HEIGHT / 4),
                 Color.White);

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
    }
}