﻿using System;
using FpsManager;
using GameStates;
using IndependentResolutionRendering;
using InputManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StateManager;

namespace Breakout
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public SpriteBatch SpriteBatch { get { return spriteBatch; } }

        private GameStateManager gameStateManager;
        private IStartState startState;
        private IPlayState playState;
        public IPlayState IPlayState { get { return playState; } }

        private FPS fps;
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Resolution.Init(ref graphics);
            Resolution.SetVirtualResolution(Constants.VIRTUAL_WIDTH, Constants.VIRTUAL_HEIGHT);
            // Resolution.SetResolution (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height, false);
            Resolution.SetResolution(1280, 720, false);
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Resize);

            Components.Add(new InputHandler(this));

            fps = new FPS(this);
            Components.Add(fps);

            gameStateManager = new GameStateManager(this);
            Components.Add(gameStateManager);

            startState = new StartState(this);
            playState = new PlayState(this);

            gameStateManager.ChangeState((StartState)startState);

        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Constants.LoadContent(Content);

        }

        protected override void Update(GameTime gameTime)
        {
            // if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            Resolution.BeginDraw();
            spriteBatch.Begin(
                SpriteSortMode.Deferred,
                null,
                SamplerState.PointClamp,
                DepthStencilState.None,
                RasterizerState.CullCounterClockwise,
                null,
                Resolution.getTransformationMatrix());
            float backgroundWidth = Constants.G_TEXTURE_BACKGROUND.Width;
            float backgroundHeight = Constants.G_TEXTURE_BACKGROUND.Height;

            spriteBatch.Draw(Constants.G_TEXTURE_BACKGROUND,
                new Vector2(0, 0),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2(Constants.VIRTUAL_WIDTH / (backgroundWidth - 1), Constants.VIRTUAL_HEIGHT / (backgroundHeight - 1)),
                SpriteEffects.None,
                0f);

            base.Draw(gameTime);

            DisplayFPS(spriteBatch);
            spriteBatch.End();
        }

        private void DisplayFPS(SpriteBatch spriteBatch)
        {
            string fpsString = string.Format("FPS: {0}", fps.FrameRate.ToString("#.##"));

            spriteBatch.DrawString(Constants.G_FONTS_SMALL, fpsString, new Vector2(5, 5), Color.Green);
        }

        private void Resize(object sender, EventArgs e)
        {
            Resolution.SetVirtualResolution(Constants.VIRTUAL_WIDTH, Constants.VIRTUAL_HEIGHT);
        }
    }
}