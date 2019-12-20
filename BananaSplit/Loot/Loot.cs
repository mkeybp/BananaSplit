using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaSplit
{
    class Loot : GameObject
    {
        public Loot()
        {
            position = new Vector2(300, 920);
        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("banana");
        }

        public override void Update(GameTime gameTime)
        {

        }
        public override void OnCollision(GameObject @object)
        {

        }
    }
}
