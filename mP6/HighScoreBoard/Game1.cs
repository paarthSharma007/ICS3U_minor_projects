using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HighScoreBoard
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont titleFont;
        SpriteFont messageFont;

        Vector2 titleLoc = new Vector2();

        Vector2 message1Loc = new Vector2();
        Vector2 message2Loc = new Vector2();
        Vector2 message3Loc = new Vector2();
        Vector2 message4Loc = new Vector2();
        Vector2 message5Loc = new Vector2();

        string title = "High Scores";

        string message1 = "Paarth : 987";
        string message2 = "Jatin : 873";
        string message3 = "Anshuman : 716";
        string message4 = "Aryan : 716";
        string message5 = "Shreyas : 489";
        
        double titleWidth;
        double message1Width;
        double message2Width;
        double message3Width;
        double message4Width;
        double message5Width;

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
            titleFont = Content.Load<SpriteFont>("Fonts/TitleFont");
            messageFont = Content.Load<SpriteFont>("Fonts/MessageFont");
            float titleWidth = titleFont.MeasureString(title).X;
            float message1Width = messageFont.MeasureString(message1).X;
            float message2Width = messageFont.MeasureString(message2).X;
            float message3Width = messageFont.MeasureString(message3).X;
            float message4Width = messageFont.MeasureString(message4).X;
            float message5Width = messageFont.MeasureString(message5).X;


            float titleHeight = titleFont.MeasureString(title).Y;
            float message1Height = messageFont.MeasureString(message1).Y;
            float message2Height = messageFont.MeasureString(message2).Y;
            float message3Height = messageFont.MeasureString(message3).Y;
            float message4Height = messageFont.MeasureString(message4).Y;
            float message5Height = messageFont.MeasureString(message5).Y;

            titleLoc = new Vector2((800/2 - titleWidth/2),482);

            message1Loc = new Vector2(800/2 - message1Width/2,502 + titleHeight + 10);
            message2Loc = new Vector2(800/2 - message2Width/2,message1Loc.Y + message1Height +10);
            message3Loc = new Vector2(800/2 - message3Width/2,message2Loc.Y + message2Height +10);
            message4Loc = new Vector2(800/2 - message4Width/2,message3Loc.Y + message3Height +10);
            message5Loc = new Vector2(800/2 - message5Width/2,message4Loc.Y + message4Height +10);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            titleLoc.Y -= 2;

            message1Loc.Y -= 2;
            message2Loc.Y -= 2;
            message3Loc.Y -= 2;
            message4Loc.Y -= 2;
            message5Loc.Y -= 2;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            _spriteBatch.DrawString(titleFont, title, titleLoc, Color.Black);
            
            _spriteBatch.DrawString(messageFont, message1, message1Loc, Color.Red);
            _spriteBatch.DrawString(messageFont, message2, message2Loc, Color.Red);
            _spriteBatch.DrawString(messageFont, message3, message3Loc, Color.Red);
            _spriteBatch.DrawString(messageFont, message4, message4Loc, Color.Red);
            _spriteBatch.DrawString(messageFont, message5, message5Loc, Color.Red);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
