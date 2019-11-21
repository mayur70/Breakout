using System;
using Breakout;
using Microsoft.Xna.Framework;

namespace StateManager {
    public class BaseGameState : GameState {
        protected static Random random = new Random ();
        protected Main GameRef;
        public BaseGameState (Game game) : base (game) {
            GameRef = (Main) game;
        }

        public override void Draw (GameTime gameTime) {
            base.Draw (gameTime);
        }

        public override void Update (GameTime gameTime) {
            base.Update (gameTime);
        }

        protected override void LoadContent () {
            base.LoadContent ();
        }

        public virtual void Reset () {

        }
    }
}