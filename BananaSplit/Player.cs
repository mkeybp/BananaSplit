using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BananaSplit
{
    class Player : GameObject
    {
        ContentManager content;
        KeyboardState previousKBState;

        private bool isGrounded = true;

        public Player()
        {
            speed = 50f;
            position = new Vector2(0, 760);


        }
        private static Vector2 playerPosition;


        public static Vector2 PlayerPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }

        public override void LoadContent(ContentManager content)
        {
            this.content = content;

            sprites = new Texture2D[3];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(i + 1 + ("player"));
            }

            fps = 8;

            sprite = sprites[0];
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput(gameTime);
            Move(gameTime);
            playerPosition = this.position;

            {

            }
            /*//Gravity(gameTime);
            if (position.X + sprite.Width < 10 || position.X > 10 + sprite.Width || position.Y + sprite.Height < 1020 || position.Y > 1020 + sprite.Height)
            {
                // No collision
                Gravity(gameTime);
            }
            else
            {
                // Collision
                if (currentKey.IsKeyDown(Keys.W) || previousKey.IsKeyDown(Keys.W))//currentKey.IsKeyDown(Keys.Up))
                {
                    velocity += new Vector2(0, -300);
                }
                Move(gameTime);
            }
            if (position.Y > 1050)
            {
                position = new Vector2(0, 760);
            }*/

            if (isGrounded == false)
            {
                Gravity(gameTime);
            }
            isGrounded = false;


        }
        private void HandleInput(GameTime gameTime)
        {
            velocity = Vector2.Zero;



            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);

            }
            if (kbState.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);

            }

            if (kbState.IsKeyDown(Keys.O))
            {

                Platform platform = new Platform(content.Load<Texture2D>("platform"));
                GameWorld.Instance.gameObjectsToAdd.Add(platform);
                platform.position = new Vector2(0,1020);
            }
            if (kbState.IsKeyDown(Keys.O))
            {
                Platform platform1 = new Platform(content.Load<Texture2D>("platform"));
                GameWorld.Instance.gameObjectsToAdd.Add(platform1);
                platform1.position = new Vector2(300, 1020);
            }
            if (kbState.IsKeyDown(Keys.W) && previousKBState.IsKeyUp(Keys.W) && isGrounded == true)
            {
                velocity += new Vector2(0, -250);

            }

            if (kbState.IsKeyDown(Keys.Space) && previousKBState.IsKeyUp(Keys.Space))
            {
                Projectile projectile = new Projectile(content.Load<Texture2D>("stone"));
                GameWorld.Instance.gameObjectsToAdd.Add(projectile);

                sprite = content.Load<Texture2D>("player_shooting");

            }


            if ((kbState.IsKeyDown(Keys.D)) || (kbState.IsKeyDown(Keys.A)) || kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Right) || kbState.IsKeyDown(Keys.Left) || kbState.IsKeyDown(Keys.Up))
            {
                Animation(gameTime);
            }

            previousKBState = kbState;


            Vector2 temp = velocity;
            temp.Y = 0;
            GameWorld.Instance.MoveAll(-temp);
        }
        private void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
        private void Gravity(GameTime gameTime)
        {
            if (position.Y < 1200 && !currentKey.IsKeyDown(Keys.W) && !currentKey.IsKeyDown(Keys.Up))
            {
                velocity += new Vector2(0, 10);
            }
            Move(gameTime);

        }
        public override void OnCollision(GameObject @object)
        {
            if (@object is Loot)
            {
                GameWorld.Instance.bananaCounter1 += 1000;
            }
            else if (@object is Enemy)
            {
                GameWorld.Instance.health--;
            }
            else if (@object is Boost)
            {
                GameWorld.Instance.bananaCounter1 += 10000;

            }
            if (!(@object is Platform))
            {
                isGrounded = false;
            }
            if (@object is Platform)
            {
                isGrounded = true;
            }

        }

    }
}
