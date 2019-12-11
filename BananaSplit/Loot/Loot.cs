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
    class Loot : GameObject
    {
        public Loot()
        {
            position = new Vector2(400, 800);
        }

        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("banana");
        }

        public override void Update(GameTime gameTime)
        {
            if (position.X + sprite.Width < 10 || position.X > 10 + sprite.Width || position.Y + sprite.Height < 10 || position.Y > 10 + sprite.Height)
            {
                // No collision
            }
            else
            {
                // Collision
               position = new Vector2(100, 100);

            }
            if (position.Y > 1080)
            {
                position = new Vector2(0, 500);
            }
        }
    }
}
