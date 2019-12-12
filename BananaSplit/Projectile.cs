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
    class Projectile : GameObject
    {
        public bool alive;

        //Player player = new Player();

        public Projectile(Texture2D loadedTexture)
        {
            this.position = new Vector2(Player.PlayerPosition.X, Player.PlayerPosition.Y);

            //position = new Vector2(player.position.X, player.position.Y);
            velocity = new Vector2(10, 0);
            sprite = loadedTexture;
            alive = true;
        }

        //public void FireProjectile()
        //{
        //    //foreach (Projectile b in projectiles)
        //    //{
        //    //    if (!b.alive)
        //    //    {
        //    //        b.alive = true;
        //    //        b.position.Y = proj.position.Y;
        //    //        b.position.X = proj.position.X + (proj.sprite.Width / 2) - (b.sprite.Width / 2);
        //    //        b.velocity = new Vector2(0, -5.0f);
        //    //        return;
        //    //    }
        //    //}
        //}

        private void UpdateProjectiles()
        {
            //foreach (Projectile p in projectiles)
            //{
            if (alive)
            {
                position += velocity;
                Rectangle viewPortRect = new Rectangle(0, 0, GameWorld.Instance.graphics.GraphicsDevice.Viewport.Width, GameWorld.Instance.graphics.GraphicsDevice.Viewport.Height);
                if (!viewPortRect.Contains(new Point((int)position.X, (int)position.Y)))
                {
                    alive = false;
                    GameWorld.Instance.gameObjectsToRemove.Add(this);
                }
            }
            //}
        }


        public override void LoadContent(ContentManager content)
        {

        }
        public override void Update(GameTime gameTime)
        {
            UpdateProjectiles();

        }

    }
}
