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
    class FixedObject
    {
        //PascalCase these variables
        public Vector2 Position;
        public Texture2D Texture;
        public Vector2 Scale;
        public Color Tint;
        public Rectangle Hitbox
        {
            get
            {
                return new Rectangle(0, 0,0,0);
            }
        }

        //constructor
        

        public void Draw(SpriteBatch batch)
        {
            //draw here
        }
    }
}
