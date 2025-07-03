using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Q2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        int screenWidth; 
        int screenHeight;

        Texture2D beachBall;

        Rectangle beachBallRec ;

        int speed = 2;
        int dirOpp = -1;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screenWidth = _graphics.GraphicsDevice.Viewport.Width;
            screenHeight = _graphics.GraphicsDevice.Viewport.Height;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            beachBall = Content.Load<Texture2D>("Images/BeachBall");
            beachBallRec = new Rectangle(400,250,(int)(beachBall.Width*0.5),(int)(beachBall.Height*0.5));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (beachBallRec.X == (screenWidth-beachBallRec.Width))
            {
                speed = speed * dirOpp;
            }

            if (beachBallRec.X == 0)
            {
                speed = speed * dirOpp;
            }

            beachBallRec.X += speed;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(beachBall,beachBallRec, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
