using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BallRacer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        bool raceOver = false;
        int winner = 0;

        Texture2D ballImg;

        Random rng;

        Vector2[] recPositions = new Vector2[4];
        Rectangle[] rectangles = new Rectangle[4];
        float[] ballSpeeds = new float[4];

        Vector2 titleLoc = new Vector2(300,200);
        Vector2 winnerLoc = new Vector2(380,300);

        SpriteFont titleFont;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            rng = new Random();

            ballImg = Content.Load<Texture2D>("BeachBall (2)");
            titleFont = Content.Load<SpriteFont>("titleFont");

            recPositions[0] = new Vector2(0,0);
            recPositions[1] = new Vector2(0,120);              
            recPositions[2] = new Vector2(0,240);
            recPositions[3] = new Vector2(0,360);

            rectangles[0] = new Rectangle((int)recPositions[0].X, (int)recPositions[0].Y,(int)ballImg.Width/3,(int)ballImg.Height/3);
            rectangles[1] = new Rectangle((int)recPositions[1].X, (int)recPositions[1].Y,(int)ballImg.Width/3,(int)ballImg.Height/3);
            rectangles[2] = new Rectangle((int)recPositions[2].X, (int)recPositions[2].Y,(int)ballImg.Width/3,(int)ballImg.Height/3);
            rectangles[3] = new Rectangle((int)recPositions[3].X, (int)recPositions[3].Y,(int)ballImg.Width/3,(int)ballImg.Height/3);

            ballSpeeds[0] = (rng.Next(20, 50) / 10f);
            ballSpeeds[1] = (rng.Next(20, 50) / 10f);
            ballSpeeds[2] = (rng.Next(20, 50) / 10f);
            ballSpeeds[3] = (rng.Next(20, 50) / 10f);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (raceOver == false)
            {
                recPositions[0].X += ballSpeeds[0];
                rectangles[0].X = (int)recPositions[0].X;

                recPositions[1].X += ballSpeeds[1];
                rectangles[1].X = (int)recPositions[1].X;

                recPositions[2].X += ballSpeeds[2];
                rectangles[2].X = (int)recPositions[2].X;

                recPositions[3].X += ballSpeeds[3];
                rectangles[3].X = (int)recPositions[3].X;

                if (rectangles[0].X >= (800 - rectangles[0].Width))
                {
                    winner = 1; 
                    raceOver = true;
                }
                if(rectangles[1].X >= (800 - rectangles[1].Width))
                {
                    winner = 2;
                    raceOver = true;
                }
                if(rectangles[2].X >= (800 - rectangles[2].Width))
                {
                    winner = 3;
                    raceOver = true;
                }
                if(rectangles[3].X >= (800 - rectangles[3].Width))
                {
                    winner = 4;
                    raceOver = true;
                }


            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (raceOver == false)
            {
                _spriteBatch.Draw(ballImg, rectangles[0], Color.White);
                _spriteBatch.Draw(ballImg, rectangles[1], Color.White);
                _spriteBatch.Draw(ballImg, rectangles[2], Color.White);
                _spriteBatch.Draw(ballImg, rectangles[3], Color.White);
            }
            else
            {
                _spriteBatch.DrawString(titleFont, "Game Over", titleLoc, Color.Black);    
                _spriteBatch.DrawString(titleFont, "" + winner, winnerLoc, Color.Black);    
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
