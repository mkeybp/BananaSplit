using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BananaSplit
{
    class Player : GameObject
    {
        ContentManager content;
        KeyboardState previousKBState;

        private bool isGrounded = true;


        //Flere sprites i et array.
        
        //En sprite.
        private Texture2D playersprite;
        public Player()
        {
            speed = 50f;
            position = new Vector2(0, 750);

            sprite = playersprite;
        }
        private static Vector2 playerPosition;
        private bool isAlive;

        public static Vector2 PlayerPosition
        {
            get { return playerPosition; }
            set { playerPosition = value; }
        }

        public override void LoadContent(ContentManager content)
        {
            this.content = content;

            sprites = new Texture2D[3];

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = content.Load<Texture2D>(i + 1 + ("player"));
            }

            fps = 8;

            sprite = sprites[0];

            //sprite = playersprite;


        }

        public override void Update(GameTime gameTime)
        {
            HandleInput(gameTime);
            Move(gameTime);
            playerPosition = this.position;


            if (playerPosition == Loot.LootPosition)
            {
                Debug.WriteLine("Hit");
                //++bananaCounter1;
                isAlive = false;
                //GameWorld.Instance.bananaCounter1++;
            }
            else
                Debug.WriteLine("miss");
            if(isGrounded == false)
            {
                Gravity(gameTime);
            }
            isGrounded = false;




            //Gravity(gameTime);
           /* if (position.X + sprite.Width < 10 || position.X > 10 + sprite.Width || position.Y + sprite.Height < 1020 || position.Y > 1020 + sprite.Height)
            {
                // No collision
                Gravity(gameTime);
            }
            else
            {
                // Collision
                if (currentKey.IsKeyDown(Keys.W) || previousKey.IsKeyDown(Keys.W))//currentKey.IsKeyDown(Keys.Up))
                {
                    velocity += new Vector2(0, -300);
                }
                Move(gameTime);
            }
            if (position.Y > 1050)
            {
                position = new Vector2(0, 750);
            }*/




        }
        private void HandleInput(GameTime gameTime)
        {
            //currentKey = Keyboard.GetState();
            //previousKey = currentKey;

            //velocity = Vector2.Zero;

            //if (currentKey.IsKeyDown(Keys.D) || (currentKey.IsKeyDown(Keys.Right)))
            //{
            //    velocity += new Vector2(1, 0);
            //}
            //if (currentKey.IsKeyDown(Keys.A) || (currentKey.IsKeyDown(Keys.Left)))
            //{
            //    velocity += new Vector2(-1, 0);
            //}
            //// Shoot
            ////if (currentKey.IsKeyDown(Keys.Space))
            ////{

            ////}

            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    Projectile projectile = new Projectile(content.Load<Texture2D>("banana"));
            //    GameWorld.Instance.gameObjectsToAdd.Add(projectile);
            //}


            //if (currentKey.IsKeyDown(Keys.W) || (currentKey.IsKeyDown(Keys.Up)))
            //{
            //    velocity += new Vector2(0, -1);
            //}


            //if ((currentKey.IsKeyDown(Keys.D)) || (currentKey.IsKeyDown(Keys.A)) || currentKey.IsKeyDown(Keys.W) || currentKey.IsKeyDown(Keys.Right) || currentKey.IsKeyDown(Keys.Left) || currentKey.IsKeyDown(Keys.Up))
            //{
            //    Animation(gameTime);
            //}
            //if (velocity != Vector2.Zero)
            //{
            //    velocity.Normalize();
            //}




            velocity = Vector2.Zero;




            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyDown(Keys.A))
            {
                velocity += new Vector2(-1, 0);

            }
            if (kbState.IsKeyDown(Keys.D))
            {
                velocity += new Vector2(1, 0);

            }


            if (kbState.IsKeyDown(Keys.W) && previousKBState.IsKeyUp(Keys.W) && isGrounded == true)
            {
                velocity += new Vector2(0, -100);
                //velocity += new Vector2()
                Move(gameTime);
            }


            Debug.WriteLine("Loot pos" + Loot.LootPosition);
            Debug.WriteLine("Player pos" + PlayerPosition);




            if (kbState.IsKeyDown(Keys.X))
            {
                position = Loot.LootPosition;


            }


            if (kbState.IsKeyDown(Keys.Space) && previousKBState.IsKeyUp(Keys.Space))
            {
                Projectile projectile = new Projectile(content.Load<Texture2D>("banana"));
                GameWorld.Instance.gameObjectsToAdd.Add(projectile);
            }

            if ((kbState.IsKeyDown(Keys.D)) || (kbState.IsKeyDown(Keys.A)) || kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Right) || kbState.IsKeyDown(Keys.Left) || kbState.IsKeyDown(Keys.Up))
            {
                Animation(gameTime);
            }


            previousKBState = kbState;


            Vector2 temp = velocity;
            temp.Y = 0;
            GameWorld.Instance.moveAll(-temp);
        }
        private void Move(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += ((velocity * speed) * deltaTime);
        }
        private void Gravity(GameTime gameTime)
        {
            if (position.Y < 1200 && !currentKey.IsKeyDown(Keys.W) && !currentKey.IsKeyDown(Keys.Up))
            {
                velocity += new Vector2(0, 5);
            }
            Move(gameTime);

        }
        public override void OnCollision(GameObject @object)
        {
            if (@object is Loot)
            {
                GameWorld.Instance.bananaCounter1++;
                this.position = new Vector2(0, 0);
            }
            if(!(@object is Platform))
            {
                isGrounded = false;
            }
            if(@object is Platform)
            {
                isGrounded = true;
            }
        }
    }
}
