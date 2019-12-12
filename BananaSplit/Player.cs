using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaSplit
{
    class Player : GameObject
    {
        ContentManager content;

        public Player()
        {
            speed = 50f;
            position = new Vector2(0, 750);
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

            //Gravity(gameTime);
            if (position.X + sprite.Width < 10 || position.X > 10 + sprite.Width || position.Y + sprite.Height < 1020 || position.Y > 1020 + sprite.Height)
            {
                // No collision
                Gravity2(gameTime);
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
                position = new Vector2(0, 750);
            }
        }
        private void HandleInput(GameTime gameTime)
        {
            currentKey = Keyboard.GetState();
            previousKey = currentKey;

            velocity = Vector2.Zero;

            if (currentKey.IsKeyDown(Keys.D) || (currentKey.IsKeyDown(Keys.Right)))
            {
                velocity += new Vector2(1, 0);
            }
            if (currentKey.IsKeyDown(Keys.A) || (currentKey.IsKeyDown(Keys.Left)))
            {
                velocity += new Vector2(-1, 0);
            }

            if (currentKey.IsKeyDown(Keys.Space))
            {
                Projectile projectile = new Projectile(content.Load<Texture2D>("banana"));
                GameWorld.Instance.gameObjectsToAdd.Add(projectile);
            }
            /*if (currentKey.IsKeyDown(Keys.W) || (currentKey.IsKeyDown(Keys.Up)))
            {
                velocity += new Vector2(0, -1);
            }*/
            if ((currentKey.IsKeyDown(Keys.D)) || (currentKey.IsKeyDown(Keys.A)) || currentKey.IsKeyDown(Keys.W) || currentKey.IsKeyDown(Keys.Right) || currentKey.IsKeyDown(Keys.Left) || currentKey.IsKeyDown(Keys.Up))
            {
                Animation(gameTime);
            }
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            Vector2 temp = velocity;
            temp.Y = 0;
            GameWorld.Instance.moveAll(-temp);
        }
        private void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
        /*private void Gravity(GameTime gameTime)
        {
            while (position.Y < 1200)
            {
                velocity += new Vector2(0, 10);
            }
            Move(gameTime);
        }*/
        private void Gravity2(GameTime gametime)
        {
            if (position.Y < 1080)//isGrounded == false)
            {
                velocity += new Vector2(0, 10 * (float)gametime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                velocity = Vector2.Zero;
            }
        }
    }
}
