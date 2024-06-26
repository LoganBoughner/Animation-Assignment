﻿using Microsoft.Xna.Framework;
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
        Texture2D backgroundTexture;
        Texture2D endTexture;
        SpriteFont instructions;
        Color randColor;
        Color orangeTribbleColorMask;
        Random randColorGen;
        Random randTribbleColorGen;
        MouseState mouseState;
        enum Screen
        {
            Intro,
            TribbleYard,
            End
        }
        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            randColor = Color.CornflowerBlue;

            brownTribbleRect = new Rectangle(300, 50, 100, 100);
            brownTribbleSpeed = new Vector2(3, 0);
            creamTribbleRect = new Rectangle(200, 100, 100, 100);
            creamTribbleSpeed = new Vector2(0, 5);
            greyTribbleRect = new Rectangle(100, 200, 100, 100);
            greyTribbleSpeed = new Vector2(4, 5);
            orangeTribbleRect = new Rectangle(10, 300, 100, 100);
            orangeTribbleSpeed = new Vector2(6, 5);
            orangeTribbleColorMask = Color.White;


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
            backgroundTexture = Content.Load<Texture2D>("background");
            endTexture = Content.Load<Texture2D>("End");
            instructions = Content.Load<SpriteFont>("Instructions");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
                

            }
            else if (screen == Screen.TribbleYard)
            {
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
                    randColorGen = new Random();
                    randColor = new Color(randColorGen.Next(256), randColorGen.Next(256), randColorGen.Next(256));
                }

                greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
                if (greyTribbleRect.Top < window.Top || greyTribbleRect.Bottom > window.Bottom)
                {
                    greyTribbleSpeed.Y *= -1;
                    randColorGen = new Random();
                    randColor = new Color(randColorGen.Next(256), randColorGen.Next(256), randColorGen.Next(256));
                }

                orangeTribbleRect.X += (int)orangeTribbleSpeed.X;
                if (orangeTribbleRect.Right > window.Width || orangeTribbleRect.X < 0)
                {
                    orangeTribbleSpeed.X *= -1;
                    randTribbleColorGen = new Random();
                    orangeTribbleColorMask = new Color(randTribbleColorGen.Next(256), randTribbleColorGen.Next(256), randTribbleColorGen.Next(256));
                }


                orangeTribbleRect.Y += (int)orangeTribbleSpeed.Y;
                if (orangeTribbleRect.Top < window.Top || orangeTribbleRect.Bottom > window.Bottom)
                {
                    orangeTribbleSpeed.Y *= -1;
                    randTribbleColorGen = new Random();
                    orangeTribbleColorMask = new Color(randTribbleColorGen.Next(256), randTribbleColorGen.Next(256), randTribbleColorGen.Next(256));
                }
               
                

            }
            if (mouseState.RightButton == ButtonState.Pressed)
                        screen = Screen.End;
            base.Update(gameTime);
        } 

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(randColor);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.DrawString(instructions, "Press LMB to start and RMB to end", new Vector2(10, 10), Color.White); ;
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribbleBrownTexture, brownTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, creamTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleGreyTexture, greyTribbleRect, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, orangeTribbleRect, orangeTribbleColorMask);
                
            }
            if (screen == Screen.End)
               _spriteBatch.Draw(endTexture, new Rectangle(0, 0, 800, 500), Color.White);
            
            
            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
