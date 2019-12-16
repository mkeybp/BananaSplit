using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace BananaSplit
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        public List<GameObject> gameObjectsToAdd = new List<GameObject>();
        public List<GameObject> gameObjectsToRemove = new List<GameObject>();

        public static GameWorld Instance;
        Song song;

        private Texture2D test;
        private Texture2D background1;
        private Texture2D background2;
        private Texture2D background3;
        private Texture2D background4;
        private Texture2D heartFull;
        private Texture2D heartEmpty;
        private Texture2D bananaPoints;
        public int bananaCounter1;
        private SpriteFont bananaCounter;

        private Vector2 screenSize;

        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Instance = this;
            bananaCounter1 = 0;
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
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();
            gameObjects = new List<GameObject>();
            gameObjects.Add(new Player());
            gameObjects.Add(new Enemy());
            gameObjects.Add(new Platform());
            gameObjects.Add(new Loot());
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
            background1 = Content.Load<Texture2D>("1background");
            background2 = Content.Load<Texture2D>("2background");
            background3 = Content.Load<Texture2D>("3background");
            background4 = Content.Load<Texture2D>("4background");
            heartFull = Content.Load<Texture2D>("heartfull");
            heartEmpty = Content.Load<Texture2D>("heartempty");
            bananaPoints = Content.Load<Texture2D>("smallBanana");
            bananaCounter = Content.Load<SpriteFont>("bananaCounter");
            song = Content.Load<Song>("By the Fire");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;

            // TODO: use this.Content to load your game content here
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent(Content);
            }
            //screenWidth = device.PresentationParameters.BackBufferWidth;
            //screenHeight = device.PresentationParameters.BackBufferHeight;
        }
        //public void moveAll(Vector2 velocity)
        //{
        //    foreach (GameObject go in gameObjects)
        //    {
        //        if (!(go is Player))
        //        {
        //            go.position += velocity * 10;
        //        }
        //        /*if (go is BackGround)
        //        {
        //            go.position += velocity * 2;
        //        }*/
        //    }
        //}



        public void moveAll(Vector2 velocity)
        {
            foreach (GameObject go in gameObjects)
            {
                if (!(go is Player) && !(go is Projectile))
                {
                    go.position += velocity * 10;
                }
                /*if (go is BackGround)
                {
                    go.position += velocity * 2;
                }*/
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

            //spriteBatch.Draw(test, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(background1, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(background2, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(background3, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(background4, new Vector2(0, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(heartFull, new Vector2(10, 15), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(heartFull, new Vector2(50, 15), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(heartFull, new Vector2(90, 15), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.Draw(bananaPoints, new Vector2(10, 70), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.DrawString(bananaCounter, ": " + bananaCounter1, new Vector2(65, 75), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            //spriteBatch.Draw(heartEmpty, new Vector2(100, 0), null, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
