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
    class Platform : GameObject
    {
        //private List<Platform> platforms = new List<Platform>();
        //Random random = new Random();
        public Platform()
        {
            
        }

        public void Initialize(GameTime gameTime)
        {
        }
        public override void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("platform");
            platforms = content.Load<Texture2D>("platform");


        }
        public override void Update(GameTime gameTime)
        {
        }
    }
}
