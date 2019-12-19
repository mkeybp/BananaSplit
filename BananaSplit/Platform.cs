﻿using Microsoft.Xna.Framework;
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

        public Platform()
        {
            position = new Vector2(0, 1020);
        }

        public void Initialize(GameTime gameTime)
        {
            //platforms.Add(new Platform());
        }
        public override void LoadContent(ContentManager content)
        {

            sprite = content.Load<Texture2D>("platform");
            //position = new Vector2(0, 425);
            //position = new Vector2(100, 425);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override Rectangle CollisionBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            }
        }
        public override void OnCollision(GameObject @object)
        {

        }
    }
}
