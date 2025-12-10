using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpelProjekt_Pevin
{ 
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;


        Texture2D apple;
        Texture2D basket;
        Rectangle basketRectangle;
        Rectangle appleRectangle;
        KeyboardState tangentbord = Keyboard.GetState();

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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            apple = Content.Load<Texture2D>("Apple");
            appleRectangle = new Rectangle(100, 100, apple.Width / 5, apple.Height / 5);
            
            basket = Content.Load<Texture2D>("Basket");
            basketRectangle = new Rectangle(400, 300, basket.Width / 5, basket.Height / 5);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            tangentbord = Keyboard.GetState();
             
            if (tangentbord.IsKeyDown(Keys.Left))
            {
                basketRectangle.X -= 3;
            }
            if (tangentbord.IsKeyDown(Keys.Right))
            {
                basketRectangle.X += 3;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(apple, appleRectangle, Color.White);
            spriteBatch.Draw(basket, basketRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
 
        }
    }
}
