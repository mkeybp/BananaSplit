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

        }

        public override void LoadContent(ContentManager content)
        {
            sprites = new Texture2D[2];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(i + 1 + ("trashcan"));
            }

            fps = 8;

            sprite = sprites[0];

        }

        public override void Update(GameTime gameTime)
        {

        }


    }
}
