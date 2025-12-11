using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SpelProjekt_Pevin
{  
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;


        Texture2D apple;
        Texture2D basket;
        Rectangle basketRectangle;
        Rectangle appleRectangle;
        KeyboardState tangentbord = Keyboard.GetState();

        Random slumpTal = new Random();

        List<Rectangle> apples = new List<Rectangle>();

        double appleTimer = 0;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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


            appleRectangle.Y += 2;

            tangentbord = Keyboard.GetState();
             
            if (tangentbord.IsKeyDown(Keys.Left))
            {
                basketRectangle.X -= 3;
            }
            if (tangentbord.IsKeyDown(Keys.Right))
            {
                basketRectangle.X += 3;
            }

            if (slumpTal.Next(0, 101) < 1)
            {
                int randomAppleX = slumpTal.Next(0, graphics.PreferredBackBufferWidth - apple.Width);
                apples.Add(new Rectangle(randomAppleX, 0 - apple.Height, apple.Width, apple.Height));
                
            }

            for (int i = 0; i < apples.Contains; i++)
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var äpple in apples)
            {
                spriteBatch.Draw(apple, appleRectangle, Color.White);
            }

            spriteBatch.Draw(apple, appleRectangle, Color.White);
            spriteBatch.Draw(basket, basketRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
 
        }
    }
}
