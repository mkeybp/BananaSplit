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
        public Player()
        {
            speed = 200f;
            position = new Vector2(0, 169);
        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[3];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(i + 1 + ("player"));
            }

            fps = 8;

            sprite = sprites [0];
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput(gameTime);
            Move(gameTime);
            //Gravity(gameTime);
            if (position.X + sprite.Width < 10 || position.X > 10 + sprite.Width || position.Y + sprite.Height < 436 || position.Y > 436 + sprite.Height)
            {
                // No collision
                Gravity(gameTime);
            }
            else
            {
                // Collision
                
            }
            if(position.Y > 240d)
            {
                position = new Vector2(0, 170);
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
            if (currentKey.IsKeyDown(Keys.W)) //&& !previousKey.IsKeyDown(Keys.Space))
            {
                velocity += new Vector2(0, -1);
            }
            if ((currentKey.IsKeyDown(Keys.D)) || (currentKey.IsKeyDown(Keys.A)) || currentKey.IsKeyDown(Keys.W) || currentKey.IsKeyDown(Keys.Right) || currentKey.IsKeyDown(Keys.Left) || currentKey.IsKeyDown(Keys.Up))
            {
                Animation(gameTime);
            }
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
        }
        private void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
        private void Gravity(GameTime gameTime)
        {
            if(position.Y < 400)
            {
            velocity += new Vector2(0, 1);
            }
            Move(gameTime);
        }
    }
}
