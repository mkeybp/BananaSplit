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
    class Enemy : GameObject
    {
        public Enemy()
        {
            position = new Vector2(291, 920);
        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[3];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(i + 1 + ("trashcan"));
            }

            fps = 3;

            //sprite = sprites[0];

        }

        public override void Update(GameTime gameTime)
        {
            Animation(gameTime);
            if (position.X + sprite.Width < 10 || position.X > 10 + sprite.Width || position.Y + sprite.Height < 1020 || position.Y > 1020 + sprite.Height)
            {
                // No collision
            }
            else
            {
                // Collision

            }
            if (position.Y > 1050)
            {
                position = new Vector2(0, 750);
            }
        }
        public override void OnCollision(GameObject other)
        {
            throw new NotImplementedException();
        }
    }
}
