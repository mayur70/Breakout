using InputManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StateManager;

namespace Breakout.GameStates {
    public interface IStartState : IGameState {

    }
    public class StartState : BaseGameState, IStartState {

        int highlighted;
        Color hightlightedColor;
        public StartState (Game game) : base (game) {
            game.Services.AddService (typeof (IStartState), this);
            hightlightedColor = new Color (103, 255, 255);
            highlighted = 0;
        }

        protected override void LoadContent () {

            base.LoadContent ();
        }

        public override void Update (GameTime gameTime) {
            if (InputHandler.IsKeyJustPressed (Keys.Up) || InputHandler.IsKeyJustPressed (Keys.Down)) {
                highlighted = highlighted == 0 ? 1 : 0;
                Constants.G_SOUNDS_PADDLE_HIT.Play ();
            }

            base.Update (gameTime);
        }

        public override void Draw (GameTime gameTime) {
            string title = "BREAKOUT";
            Vector2 msgSize = Constants.G_FONTS_LARGE.MeasureString (title);
            GameRef.SpriteBatch.DrawString (Constants.G_FONTS_LARGE, title,
                new Vector2 ((Constants.VIRTUAL_WIDTH / 2) - (msgSize.X / 2), Constants.VIRTUAL_HEIGHT / 3), Color.White);

            string startMsg = "START";

            msgSize = Constants.G_FONTS_MEDIUM.MeasureString (startMsg);
            Color currentColor;
            if (highlighted == 0) {
                currentColor = hightlightedColor;
            } else {
                currentColor = Color.White;
            }
            GameRef.SpriteBatch.DrawString (Constants.G_FONTS_MEDIUM, startMsg,
                new Vector2 ((Constants.VIRTUAL_WIDTH / 2) - (msgSize.X / 2), Constants.VIRTUAL_HEIGHT / 2 + 70), currentColor);

            string hightScoreMsg = "HIGH SCORES";
            msgSize = Constants.G_FONTS_MEDIUM.MeasureString (hightScoreMsg);

            if (highlighted == 1) {
                currentColor = hightlightedColor;
            } else {
                currentColor = Color.White;
            }
            GameRef.SpriteBatch.DrawString (Constants.G_FONTS_MEDIUM, hightScoreMsg,
                new Vector2 ((Constants.VIRTUAL_WIDTH / 2) - (msgSize.X / 2), Constants.VIRTUAL_HEIGHT / 2 + 90), currentColor);

            base.Draw (gameTime);
        }

        protected override void UnloadContent () {
            base.UnloadContent ();
        }
    }
}