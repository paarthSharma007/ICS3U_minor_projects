using GameUtility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;  //Required for sound effects
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;  //Required for songs
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoundTimersStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //constants for each game state
        const int PLAY = 0;
        const int PAUSE = 1;

        //Track all available sprite fonts
        SpriteFont timerFont;
        SpriteFont messageFont;

        //Store the images used throughout the demo
        Texture2D ballImg;
        Texture2D bulletImg;
        Texture2D explodeImg;

        //Store the true positions of each image
        Vector2 ballPos;
        Vector2 bulletPos;
        Vector2 explodePos;

        //Store where the pause message will display
        Vector2 pauseTextLoc;

        //Track the bounding rectangles of the two moving objects
        Rectangle ballRec;
        Rectangle bulletRec;

        //Store the animation for the explosion
        Animation explodeAnim;

        //Store the velocities of the two moving objects
        Vector2 ballSpeed = new Vector2(5f, 2f);
        Vector2 bulletSpeed = new Vector2(-3f, 10f);

        //track the screen dimensions
        int screenWidth;
        int screenHeight;

        //Track the keyboard states
        KeyboardState prevKb;
        KeyboardState kb;

        //Track the current game state
        int gameState = PLAY;

        //Store the background music
        Song bgMusic;

        //Store the various sound effects
        SoundEffect pauseSnd;
        SoundEffect bounceSnd;
        SoundEffect boomSnd;

        //How long a message is displayed on the screen (Progression timer)
        Timer messageTimer;
        Vector2 timerLoc;

        //Track the total time played (Infinite timer)
        Timer gameTimer;
        Vector2 gameTimerLoc;

        //Trigger an explosion every time the timer is Finished (Spawn timer)
        Timer triggerTimer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;

            //retrieve the current screen dimensions
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load in the fonts
            timerFont = Content.Load<SpriteFont>("Fonts/TimerFont");
            messageFont = Content.Load<SpriteFont>("Fonts/MessageFont");

            //Load in the image data
            ballImg = Content.Load<Texture2D>("Images/Sprites/Ball");
            bulletImg = Content.Load<Texture2D>("Images/Sprites/Bullet");
            explodeImg = Content.Load<Texture2D>("Images/Sprites/explode");

            //Load in the background music
            bgMusic = Content.Load<Song>("Audio/Music/Tetris");

            //Load in the sound effects
            pauseSnd = Content.Load<SoundEffect>("Audio/Sounds/PauseMenu");
            bounceSnd = Content.Load<SoundEffect>("Audio/Sounds/Dink");
            boomSnd = Content.Load<SoundEffect>("Audio/Sounds/Explosion");

            //Store the pause text location
            pauseTextLoc = new Vector2(300, 10);

            //Store the true positions of the moving objects and the explosion animation
            ballPos = new Vector2(100, 100);
            bulletPos = new Vector2(100, screenHeight - 100);
            explodePos = new Vector2(screenWidth / 2, screenHeight / 2);

            //Store the bounding boxes for the moving objects
            ballRec = new Rectangle((int)ballPos.X, (int)ballPos.Y, ballImg.Width / 3, ballImg.Height / 3);
            bulletRec = new Rectangle((int)bulletPos.X, (int)bulletPos.Y, bulletImg.Width / 4, bulletImg.Height / 4);

            //Create the exploding animation object
            explodeAnim = new Animation(explodeImg, 5, 5, 23, 0, Animation.NO_IDLE, Animation.ANIMATE_ONCE, 500, explodePos, 2,false);

            //A 2 second timer for the pause text to show
            messageTimer = new Timer(2000, false);
            timerLoc = new Vector2(0, 450);

            //Start timing immediately because the game starts in the PLAY gameState
            gameTimer = new Timer(Timer.INFINITE_TIMER, true);
            gameTimerLoc = new Vector2(0, 0);

            //Set up a 4 second spawn timer for the explosion animation
            triggerTimer = new Timer(4000, true);

            //Set the volume of the music to 20%
            MediaPlayer.Volume = 0.2f;

            //Uncomment this if music is to start immediately
            //MediaPlayer.Play(bgMusic);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update the keyboard states
            prevKb = kb;
            kb = Keyboard.GetState();

            //Update the active game state only
            switch (gameState)
            {
                case PLAY:

                    //Play the background music if it is not currently playing
                    if (MediaPlayer.State != MediaState.Playing)
                    {
                        MediaPlayer.Play(bgMusic);
                    }

                    //Pause the game when the P key is pressed
                    if (kb.IsKeyDown(Keys.P) && !prevKb.IsKeyDown(Keys.P))
                    {
                        //Play the pause sound effect at 30% volume
                        SoundEffectInstance pauseSndInst = pauseSnd.CreateInstance();
                        pauseSndInst.Volume = 0.3f;
                        pauseSndInst.Play();

                        //Reset and activate the message timer
                        messageTimer.ResetTimer(true);

                        //Change the game state to PAUSE
                        gameState = PAUSE;
                    }
                    
                    //Start the explosion animation if the space key is pressed
                    if (kb.IsKeyDown(Keys.Space) && !prevKb.IsKeyDown(Keys.Space))
                    {
                        //Play the explosion sound effect
                        boomSnd.CreateInstance().Play();

                        //Activate and reset the explosion animation
                        explodeAnim.Activate(true);
                    }

                    //Update the animation and timers used in game play
                    explodeAnim.Update(gameTime);
                    gameTimer.Update(gameTime);
                    triggerTimer.Update(gameTime);

                    //Move the ball and bullet by their relative speeds
                    ballPos += ballSpeed;
                    bulletPos += bulletSpeed;

                    //Update the ball and  bullet's bounding rectangle to match their true position
                    ballRec.X = (int)ballPos.X;
                    ballRec.Y = (int)ballPos.Y;
                    bulletRec.X = (int)bulletPos.X;
                    bulletRec.Y = (int)bulletPos.Y;

                    //Activate the explosion animation when the trigger time has completed
                    if (triggerTimer.IsFinished())
                    {
                        //Reset the timer to explode again
                        triggerTimer.ResetTimer(true);

                        //Play the explosion sound effect
                        boomSnd.CreateInstance().Play();

                        //Cause the explode animation to start
                        explodeAnim.Activate(true);
                    }

                    //Ball and Bullet edge collision
                    if (ballRec.Left <= 0)
                    {
                        //Relocate the ball to be at the screen edge
                        ballPos.X = 0;
                        ballRec.X = (int)ballPos.X;

                        //Reverse the ball's X speed
                        ballSpeed.X *= -1;

                        //Play the bounce sound effect
                        bounceSnd.CreateInstance().Play();
                    }
                    else if (ballRec.Right >= screenWidth)
                    {
                        //Relocate the ball to be at the screen edge
                        ballPos.X = screenWidth - ballRec.Width;
                        ballRec.X = (int)ballPos.X;

                        //Reverse the ball's X speed
                        ballSpeed.X *= -1;

                        //Play the bounce sound effect
                        bounceSnd.CreateInstance().Play();
                    }
                    else if (ballRec.Top <= 0)
                    {
                        //Relocate the ball to be at the screen edge
                        ballPos.Y = 0;
                        ballRec.Y = (int)ballPos.Y;

                        //Reverse the ball's Y speed
                        ballSpeed.Y *= -1;

                        //Play the bounce sound effect
                        bounceSnd.CreateInstance().Play();
                    }
                    else if (ballRec.Bottom >= screenHeight)
                    {
                        //Relocate the ball to be at the screen edge
                        ballPos.Y = screenHeight - ballRec.Height;
                        ballRec.Y = (int)ballPos.Y;

                        //Reverse the ball's Y speed
                        ballSpeed.Y *= -1;

                        //Play the bounce sound effect
                        bounceSnd.CreateInstance().Play();
                    }
                    
                    //You can repeat the accurate edge collision above for the bullet too
                    if (bulletRec.Left <= 0 || bulletRec.Right >= screenWidth)
                    {
                        //Reverse the bullet's X speed
                        bulletSpeed.X *= -1;

                        //Play the bounce sound effect
                        bounceSnd.CreateInstance().Play();
                    }
                    else if (bulletRec.Top <= 0 || bulletRec.Bottom >= screenHeight)
                    {
                        //Reverse the bullet's Y speed
                        bulletSpeed.Y *= -1;

                        //Play the bounce sound effect
                        bounceSnd.CreateInstance().Play();
                    }
                    break;
                case PAUSE:
                    //Update the message timer used for the pause text
                    messageTimer.Update(gameTime);

                    //Unpause the game when the P key is pressed
                    if (kb.IsKeyDown(Keys.P) && !prevKb.IsKeyDown(Keys.P))
                    {
                        //Play the pause sound effect
                        SoundEffectInstance pauseSndInst = pauseSnd.CreateInstance();
                        pauseSndInst.Volume = 0.3f;
                        pauseSndInst.Play();

                        //Deactivate the message timer
                        messageTimer.Deactivate();

                        //Set the game state back to PLAY
                        gameState = PLAY;
                    }
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Redraw the background as Black
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            //Only draw the current game state
            switch (gameState)
            {
                case PLAY:
                    //Draw the moving objects
                    spriteBatch.Draw(ballImg, ballRec, Color.White);
                    spriteBatch.Draw(bulletImg, bulletRec, Color.White);

                    //Draw the explosion animation
                    explodeAnim.Draw(spriteBatch, Color.White);

                    //Draw the game timer to track total time played
                    spriteBatch.DrawString(timerFont, gameTimer.GetTimePassedAsString(Timer.FORMAT_SEC_MIL), gameTimerLoc, Color.White);
                    break;
                case PAUSE:
                    //Draw the moving objects
                    spriteBatch.Draw(ballImg, ballRec, Color.White);
                    spriteBatch.Draw(bulletImg, bulletRec, Color.White);

                    //Draw the explosion animation
                    explodeAnim.Draw(spriteBatch, Color.White);

                    //Draw the timer for the message timer with remaining time (this is not necessary)
                    spriteBatch.DrawString(timerFont, messageTimer.GetTimeRemainingAsString(Timer.FORMAT_SEC_MIL), timerLoc, Color.White);

                    //Only draw the PAUSED text if the message timer is still active
                    if (messageTimer.IsActive())
                    {
                        //Draw the message text normally
                        //spriteBatch.DrawString(messageFont, "PAUSED", pauseTextLoc, Color.White);

                        //Draw the message text fade out based on timeRemaining/totalTime = a % of opacity
                        spriteBatch.DrawString(messageFont, "PAUSED", pauseTextLoc, Color.White * (float)(messageTimer.GetTimeRemaining() / messageTimer.GetTargetTime()));
                    }
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}