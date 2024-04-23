using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Animation_Assignment
{
    public class Game1 : Game
    {
        // Logan
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle window;
        Texture2D tribbleBrownTexture;
        Rectangle brownTribbleRect;
        Vector2 brownTribbleSpeed;
        Texture2D tribbleCreamTexture;
        Rectangle creamTribbleRect;
        Vector2 creamTribbleSpeed;
        Texture2D tribbleGreyTexture;
        Rectangle greyTribbleRect;
        Vector2 greyTribbleSpeed;
        Texture2D tribbleOrangeTexture;
        Rectangle orangeTribbleRect;
        Vector2 orangeTribbleSpeed;
        Color randColor;
        Random gen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            randColor = Color.CornflowerBlue;

            brownTribbleRect = new Rectangle(300, 50, 100, 100);
            brownTribbleSpeed = new Vector2(3, 0);
            creamTribbleRect = new Rectangle(200, 100, 100, 100);
            creamTribbleSpeed = new Vector2(0, 5);
            greyTribbleRect = new Rectangle(100, 200, 100, 100);
            greyTribbleSpeed = new Vector2(-3, 5);
            orangeTribbleRect = new Rectangle(10, 300, 100, 100);
            orangeTribbleSpeed = new Vector2(-3, -5);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            brownTribbleRect.X += (int)brownTribbleSpeed.X;
            if (brownTribbleRect.Right > window.Width || brownTribbleRect.X < 0)
                brownTribbleSpeed.X *= -1;

            brownTribbleRect.Y += (int)brownTribbleSpeed.Y;
            if (brownTribbleRect.Top < window.Top || brownTribbleRect.Bottom > window.Bottom)
                brownTribbleSpeed.Y *= -1;

            creamTribbleRect.X += (int)creamTribbleSpeed.X;
            if (creamTribbleRect.Right > window.Width || creamTribbleRect.X < 0)
                creamTribbleSpeed.X *= -1;

            creamTribbleRect.Y += (int)creamTribbleSpeed.Y;
            if (creamTribbleRect.Top < window.Top || creamTribbleRect.Bottom > window.Bottom)
                creamTribbleSpeed.Y *= -1;

            greyTribbleRect.X += (int)greyTribbleSpeed.X;
            if (greyTribbleRect.Right > window.Width || greyTribbleRect.X < 0)
            {
                greyTribbleSpeed.X *= -1;
                gen = new Random();
                randColor = new Color(gen.Next(256), gen.Next(256), gen.Next(256));
            }

            greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
            if (greyTribbleRect.Top < window.Top || greyTribbleRect.Bottom > window.Bottom)
                greyTribbleSpeed.Y *= -1;

            orangeTribbleRect.X += (int)orangeTribbleSpeed.X;
            if (orangeTribbleRect.Right > window.Width || orangeTribbleRect.X < 0)
            {
                orangeTribbleSpeed.X *= -1;

            }


            orangeTribbleRect.Y += (int)orangeTribbleSpeed.Y;
            if (orangeTribbleRect.Top < window.Top || orangeTribbleRect.Bottom > window.Bottom)
                orangeTribbleSpeed.Y *= -1;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(randColor);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleBrownTexture, brownTribbleRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, creamTribbleRect, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, greyTribbleRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, orangeTribbleRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
