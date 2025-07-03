using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace mP7
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int screenWidth;
        int screenHeight;
        int TargetFPS = 30;

        Texture2D beachBallImg;
        Texture2D backgroundImg;

        Rectangle beachBall1Rec ;
        Rectangle beachBall2Rec ;
        Rectangle backgroundRec ;

        Vector2 beachBall1Loc ;
        Vector2 beachBall2Loc ;

        float ball1SpeedX = 1.3f;
        float ball1SpeedY = 1.3f;
        float ball2speedX = 200.0f;
        float ball2speedY = 200.0f;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //_graphics.PreferredBackBufferWidth = 1920;
            //_graphics.PreferredBackBufferHeight = 1080;

            _graphics.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / TargetFPS);

            _graphics.ApplyChanges();

            screenWidth = _graphics.GraphicsDevice.Viewport.Width;
            screenHeight = _graphics.GraphicsDevice.Viewport.Height;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            beachBallImg = Content.Load<Texture2D>("Images/BeachBall");
            backgroundImg = Content.Load<Texture2D>("Images/background");

            beachBall1Loc = new Vector2(700,10);

            beachBall2Loc = new Vector2((int)(screenWidth / 2 - (beachBallImg.Width * 0.25f)) / 2, (int)(screenHeight - (beachBallImg.Height * 0.25f)));
 
            beachBall1Rec = new Rectangle((int)beachBall1Loc.X,(int)beachBall1Loc.Y, (int)(beachBallImg.Width * 0.5f), (int)(beachBallImg.Height * 0.5f));
            beachBall2Rec = new Rectangle((int)beachBall2Loc.X,(int)beachBall2Loc.Y,(int)(beachBallImg.Width * 0.25f), (int)(beachBallImg.Height * 0.25f));
            backgroundRec = new Rectangle(0, 0, backgroundImg.Width, backgroundImg.Height);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            beachBall1Loc.X -= ball1SpeedX;
            beachBall1Loc.Y += ball1SpeedY;

            beachBall2Loc.X += ball2speedX;
            beachBall2Loc.Y += ball2speedY;

            beachBall1Rec.X = (int)beachBall1Loc.X;
            beachBall1Rec.Y = (int)beachBall1Loc.Y;

            beachBall2Rec.X = (int)beachBall2Loc.X;
            beachBall2Rec.Y = (int)beachBall2Loc.Y;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundImg, backgroundRec , Color.White);
            _spriteBatch.Draw(beachBallImg , beachBall1Rec , Color.White);
            _spriteBatch.Draw(beachBallImg, beachBall2Rec , Color.White); // this won't be visible to the screen as it's speed per second is more than the screen's size so it will fly past
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
