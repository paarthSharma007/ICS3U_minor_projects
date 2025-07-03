using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoOutputPractice
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont leftScreen;
        SpriteFont rightScreen;

        Vector2 usernameLoc = new Vector2(5, 10);
        Vector2 healthLoc = new Vector2(5, 450);
        Vector2 highScoreLoc = new Vector2(590, 10);
        Vector2 timerLoc = new Vector2(740, 450);

        string username = "Transformer";
        string health = "HP : 95";
        string highScore = "SCORE : 20000";
        string timer = "5:25";
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
            leftScreen = Content.Load<SpriteFont>("Fonts/LeftscreenFont");
            rightScreen = Content.Load<SpriteFont>("Fonts/RightscreenFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
                                                                                       
            base.Update(gameTime);                                                     
        }                                                                              
                                                                                       
        protected override void Draw(GameTime gameTime)                                
        {                                                                              
            GraphicsDevice.Clear(Color.CornflowerBlue);                                
                                                                                       
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(leftScreen, username,usernameLoc,Color.Black);
            _spriteBatch.DrawString(leftScreen, health, healthLoc, Color.Black);
            _spriteBatch.DrawString(rightScreen, highScore, highScoreLoc, Color.Black);
            _spriteBatch.DrawString(rightScreen, timer, timerLoc, Color.Black);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
