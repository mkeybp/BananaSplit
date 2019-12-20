using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BananaSplit
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        public List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> gameObjectsToAdd = new List<GameObject>();
        public List<GameObject> gameObjectsToRemove = new List<GameObject>();

        public static GameWorld Instance;
        Song song;

        private Texture2D background;
        private Texture2D heartFull;
        private Texture2D bananaPoints;
        public int bananaCounter;
        public int health;
        private SpriteFont text;



        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
            bananaCounter = 0;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            gameObjects = new List<GameObject>();
            gameObjects.Add(new Player());
            gameObjects.Add(new Enemy());
            //gameObjects.Add(new Platform());
            gameObjects.Add(new Loot());
            gameObjects.Add(new Boost());

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

            //test = Content.Load<Texture2D>("test");
            background = Content.Load<Texture2D>("background");
            heartFull = Content.Load<Texture2D>("heartfull");
            bananaPoints = Content.Load<Texture2D>("smallBanana");
            text = Content.Load<SpriteFont>("gameOver");
            song = Content.Load<Song>("By the Fire");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;


            gameObjects.Add(new Platform(new Vector2(-295, 1000)));
            gameObjects.Add(new Platform(new Vector2(-295, 900)));
            gameObjects.Add(new Platform(new Vector2(-295, 800)));
            gameObjects.Add(new Platform(new Vector2(-295, 700)));
            gameObjects.Add(new Platform(new Vector2(-295, 600)));
            gameObjects.Add(new Platform(new Vector2(-295, 500)));

            gameObjects.Add(new Platform(new Vector2(0, 1000)));
            gameObjects.Add(new Platform(new Vector2(295, 1000)));
            gameObjects.Add(new Platform(new Vector2(590, 1000)));
            gameObjects.Add(new Platform(new Vector2(885, 1000)));
            gameObjects.Add(new Platform(new Vector2(1180, 1000)));
            gameObjects.Add(new Platform(new Vector2(1475, 1000)));

            gameObjects.Add(new Platform(new Vector2(1770, 900)));
            gameObjects.Add(new Platform(new Vector2(2065, 800)));
            gameObjects.Add(new Platform(new Vector2(2360, 750)));
            gameObjects.Add(new Platform(new Vector2(2655, 700)));
            gameObjects.Add(new Platform(new Vector2(2950, 800)));
            gameObjects.Add(new Platform(new Vector2(3245, 900)));

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent(Content);
            }

        }


        public void MoveAll(Vector2 velocity)
        {
            foreach (GameObject go in gameObjects)
            {
                if (!(go is Player) && !(go is Projectile))
                {
                    go.position += velocity * 15;
                }
            }
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

            // TODO: Add your update logic here

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }
            foreach (GameObject gameObject in gameObjects)
            {
                foreach (GameObject gameObject1 in gameObjects)
                {
                    if (gameObject == gameObject1)
                        continue;

                    gameObject.CheckCollision(gameObject1);
                }
            }
            base.Update(gameTime);
            gameObjects.AddRange(gameObjectsToAdd);
            gameObjects.RemoveAll(go => gameObjectsToRemove.Contains(go));
            gameObjectsToRemove.Clear();



            gameObjectsToAdd.Clear();
        }





        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {



            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);


            if (health >= 10 || health >= 20 || health >= 30)
            {
                spriteBatch.Draw(heartFull, new Vector2(10, 15), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
            if (health >= 20 || health >= 30)
            {
                spriteBatch.Draw(heartFull, new Vector2(50, 15), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            }
            if (health >= 30)
            {
                spriteBatch.Draw(heartFull, new Vector2(90, 15), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            }



            spriteBatch.Draw(bananaPoints, new Vector2(10, 70), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.DrawString(text, ": " + bananaCounter, new Vector2(65, 75), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            int bananasNeeded = 40000 - bananaCounter;

            // GameoverTxT
            if (health <= 0)
            {
                //isAlive = false;
                spriteBatch.DrawString(text,
                                       "You only needed " + bananasNeeded + " more bananas, to remove banana-food-waste for today.\n See you again tomorrow for 40.000 more \n BUT you gathered enough bananas to produce {x_amount} of ice cream \n\n PRESS ENTER TO PLAY AGAIN",
                                       new Vector2(150, graphics.GraphicsDevice.Viewport.Height / 2),
                                       Color.White,
                                       0,
                                       Vector2.Zero,
                                       1,
                                       SpriteEffects.None,
                                       0);
            }
            if (bananaCounter >= 40000)
            {
                bananaCounter = 40000;
            }
            if (bananaCounter == 40000 && health > 0)
            {

                //spriteBatch.Draw(background, new Vector2(0, 0), null, Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1f);


                spriteBatch.DrawString(text,
                                 "Congrats! You made it to level 2! \n In England they discard around 1.500.000 bananas EVERY day!\n Collect all 1.500.000 to advance to win the game \n and to produce {x_amount} of ice cream!"
,
                                 new Vector2(150, graphics.GraphicsDevice.Viewport.Height / 2),
                                 Color.White,
                                 0,
                                 Vector2.Zero,
                                 1,
                                 SpriteEffects.None,
                                 0);
            }



            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
