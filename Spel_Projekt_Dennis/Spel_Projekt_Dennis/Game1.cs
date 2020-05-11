using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spel_Projekt_Dennis
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        List<Enemies> enemies;
        Base bas;
        SpriteFont font;
        HighScore highscore;
        double timeSinceLastKill = 0;
        //public enum State { Menu, Level, EnterHighscore, Highscore, Quit };
        //public static State currentstate;
        

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

            highscore = new HighScore(5);
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            enemies = new List<Enemies>();
            Random random = new Random();            
            player = new Player(Content.Load<Texture2D>("sprites/player/tempplayer"), 380,400);

            Texture2D tempSprite = Content.Load<Texture2D>("sprites/enemies/tempenemy");
            for (int i = 0; i < 5; i++)
            {
                int rndX = random.Next(100, Window.ClientBounds.Width - tempSprite.Width - 100);
                int tempY = 100;                
                NormalZombieBear temp = new NormalZombieBear(tempSprite, rndX, tempY, 1f, 0,0);
                enemies.Add(temp);
            }
            bas = new Base(Content.Load<Texture2D>("sprites/player/Stacket"), 0, 280);

            //font = Content.Load<SpriteFont>("sprites/Fonts/firstfont");

            GameElements.LoadContent(Content, Window);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
            //highscore.SaveToFile("highscore.txt");

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

            Random random = new Random();
            MouseState state = Mouse.GetState();
            Texture2D tempSprite = Content.Load<Texture2D>("sprites/enemies/tempenemy");


            player.Update(Window,gameTime);
            {
            foreach(Enemies e in enemies.ToList())
                if (e.IsAlive)
                {
                    e.Update(Window);
                    
                    if (state.LeftButton == ButtonState.Pressed && player.CheckCollision(e))
                    {   
                        if (gameTime.TotalGameTime.TotalMilliseconds > timeSinceLastKill + 300)
                        {
                            e.IsAlive = false;
                            player.Points++;
                            enemies.Remove(e); 
                        }                                             
                                                                      
                    }
                    if (bas.CheckCollision(e))
                    {
                        player.IsAlive = false;
                    }
                }
                if (enemies.Count < 5)
                {
                    int rndX = random.Next(100, Window.ClientBounds.Width - tempSprite.Width - 100);
                    int tempY = 100;
                    NormalZombieBear temp = new NormalZombieBear(tempSprite, rndX, tempY, 1f, 0, 0);
                    enemies.Add(temp);
                }
                
            }

            
            /*switch (currentstate)
            {
                case State.Menu:
                    

                default:
                    KeyboardState keyboardState = Keyboard.GetState();
                    currentStateHigh = State.EnterHighScore;
                    break;
            }if (highscore.EnterUpdate(gameTime, player.Points)) currentStateHigh = State.PrintHighScore;
                    break;*/

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            /*switch (currentStateHigh)
            {
                case State.EnterHighScore:
                    highscore.EnterDraw(spriteBatch, font);
                    break;
                default:
                    highscore.PrintDraw(spriteBatch, font);
                    break;
            }*/
            
            foreach(Enemies e in enemies) e.Draw(spriteBatch);
            player.Draw(spriteBatch);
            bas.Draw(spriteBatch);
            //spriteBatch.DrawString(font, "highscore!!", new Vector2(5,5), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
