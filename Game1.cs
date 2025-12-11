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
        double basketX;
        int score = 0;

        SpriteFont scoreFont;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            apple = Content.Load<Texture2D>("Apple");
            appleRectangle = new Rectangle(100, 100, apple.Width / 2, apple.Height / 2);

            basket = Content.Load<Texture2D>("Basket");
            basketRectangle = new Rectangle(400, 300, basket.Width / 5, basket.Height / 5);

            scoreFont = Content.Load<SpriteFont>("ScoreFont");

            basketX = basketRectangle.X;



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState key = Keyboard.GetState();

            tangentbord = Keyboard.GetState();
             
            if (tangentbord.IsKeyDown(Keys.Left))
            {
                basketRectangle.X -= 5;
            }
            if (tangentbord.IsKeyDown(Keys.Right))
            {
                basketRectangle.X += 5;
            }

            if (slumpTal.Next(0, 101) < 0.5)
            {
                int randomAppleX = slumpTal.Next(0, graphics.PreferredBackBufferWidth - apple.Width);
                apples.Add(new Rectangle(randomAppleX, 0 - apple.Height, apple.Width, apple.Height));
                
            }

            for (int i = apples.Count - 1; i >= 0; i--)
            {
                Rectangle a = apples[i];

                a.Y += 4;

                apples[i] = a;

                if (a.Intersects(basketRectangle))
                {
                    score++;
                    apples.RemoveAt(i);
                }
                else if (a.Y > graphics.PreferredBackBufferHeight)
                {
                    apples.RemoveAt(i);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (var a in apples)
            {
                spriteBatch.Draw(apple, a, Color.White);
            }

            spriteBatch.Draw(basket, basketRectangle, Color.White);

            spriteBatch.DrawString(scoreFont, $"Score: {score}", new Vector2(10, 10), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
 
        }
    }
}
