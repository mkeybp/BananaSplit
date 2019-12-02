using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaSplit
{
    public abstract class GameObject
    {
        //Flere sprites i et array.
        protected Texture2D[] sprites;
        //En sprite.
        protected Texture2D sprite;
        //Frames per seconds, bruges til animation af sprites.
        protected int fps;
        //Bruges til Player og Enemey movement.
        protected float speed;
        //Bruges også til Player og Enemy movement.
        protected float velocity;
        //Bruges til Player og Enemy position.
        protected Vector2 origin;
        //Holder styr på hvilken tast som bliver brugt i øjeblikket.
        protected KeyboardState currentKey;
        //Holder styr på hvilken key som blev brugt sidst.
        protected KeyboardState previousKey;
    }
}
