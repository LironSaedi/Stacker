using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker
{

    //FixedObject class: position, texture, scale, color, hitbox, Draw()
    //MovingObject : FixedObject + Speed, Update()
    class MovingObject : FixedObject
    {
        public Vector2 Speed;
        public int Score;

        public MovingObject(Texture2D image, Vector2 position, Color color, Vector2 speed) : base(position, image, new Vector2(1,1), color)
        {
            this.Speed = speed;
            Score = 0;
        }

            //if right side hits right wall, reverse speed
        // update

        public void Update ()
        {
            //move object by speed
            Position += Speed;
        }
   

    }
}

