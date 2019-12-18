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
    class Enemy : GameObject
    {

        public int enemyHealth = 2;

        public Enemy()
        {
            position = new Vector2(700, 750);
            speed = 2f;

        }

        public override void LoadContent(ContentManager content)
        {
            if (enemyHealth == 2 || enemyHealth == 1)
            {


                sprites = new Texture2D[3];

                for (int i = 0; i < sprites.Length; i++)
                {
                    sprites[i] = content.Load<Texture2D>(i + 1 + ("trashcan"));
                }

                fps = 3;

                //sprite = sprites[0];
            }
            Debug.WriteLine(enemyHealth);

        }

        public override void Update(GameTime gameTime)
        {
            EnemyMove(gameTime);
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

        /// <summary>
        /// This is from another project, and should not be taken into the valuation
        /// </summary>
        #region ENEMYMOVE FROM ANOTHER PROJECT
        // Distance
        private Vector2 distance;
        // Direction of the enemy
        private Vector2 direction;
        // Rotation of player and enemy
        protected float rotation;
        private void EnemyMove(GameTime gameTime)
        {
            // Calculates the distance from the player and the enemy
            distance.X = Player.PlayerPosition.X - position.X;
            distance.Y = Player.PlayerPosition.Y - position.Y;

            rotation = (float)Math.Atan2(distance.X, -distance.Y);
            direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));

            float positiveDistanceX = distance.X;
            float positiveDistanceY = distance.Y;
            if (distance.X < 0)
            {
                positiveDistanceX *= -1;

            }
            if (distance.Y < 0)
                positiveDistanceY *= -1;

            if (positiveDistanceX > 50 || positiveDistanceY > 50)
                position += direction * this.speed;


        }
        #endregion ENEMYMOVE FROM ANOTHER PROJECT

        public override void OnCollision(GameObject @object)
        {
            //if (@object is Projectile)
            //{
            //    enemyHealth--;
            //}
        }
    }
}
