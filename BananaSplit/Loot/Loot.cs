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

        public Player player = new Player();
        private Texture2D lootSprite;

        //Texture2D lootSprite;


        public Loot()
        {
            position = new Vector2(0, 750);
            //sprite = new lootSprite;
        }
        private static Vector2 lootPosition;
        public static Vector2 LootPosition
        {
            get { return lootPosition; }
            set { lootPosition = value; }
        }
        public override void LoadContent(ContentManager content)
        {


            sprite = lootSprite = content.Load<Texture2D>("banana");

        }

        /// Todo:
        /// get set loot position. ELLER Hardcode en position
        /// 

        public override void Update(GameTime gameTime)
        {

            lootPosition = this.position;


            //if (Player.PlayerPosition.X + sprite.Width < 100 || Player.PlayerPosition.X > 100 + lootSprite.Width || position.Y + sprite.Height < 100 || Player.PlayerPosition.Y > 100 + lootSprite.Height)
            //{
            //    Debug.WriteLine("Works");

            //}
            //else
            //{
            //    Debug.WriteLine("done");
            //}


            //if (Player.PlayerPosition.X + sprite.Width < 10 || Player.PlayerPosition.X > 10 + sprite.Width || Player.PlayerPosition.Y + sprite.Height < 10 || Player.PlayerPosition.Y > 10 + sprite.Height)
            //{
            //    // No collision
            //}
            //else
            //{
            //    // Collision
            //    position = new Vector2(100, 100);

            //}
            //if (position.Y > 1080)
            //{
            //    position = new Vector2(0, 500);
            //}
        }
    }
}
