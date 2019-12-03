using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[2];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(i + 1 + ("player"));
            }

            fps = 5;

            sprite = sprites [0];
            
        }

        public override void Update(GameTime gameTime)
        {
            HandleInput(gameTime);
            Move(gameTime);
        }

        public void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }

        public void HandleInput(GameTime gameTime)
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            velocity = Vector2.Zero;

            if (currentKey.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);
            }
            if(currentKey.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);
            }
            if(currentKey.IsKeyDown(Keys.W))
            {
                velocity += new Vector2(0, -1);
            }
            if((currentKey.IsKeyDown(Keys.D)) || (currentKey.IsKeyDown(Keys.D)) || currentKey.IsKeyDown(Keys.D))
            {
                Animation(gameTime);
            }
        }
    }
}
