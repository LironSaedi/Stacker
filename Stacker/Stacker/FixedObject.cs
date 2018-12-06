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
        // DONE : PascalCase these variables 
        public Vector2 Position;
        public Texture2D Texture;
        public Vector2 Scale;
        public Color Tint;
        public Rectangle Hitbox
        {
            get
            {
                //TODO fix this
                return new Rectangle((int)Position.X, (int)Position.Y, (int)(Texture.Width * Scale.X),(int)(Texture.Height * Scale.Y));
            }
        }

        //constructor
        public FixedObject(Vector2 Position, Texture2D Texture, Vector2 Scale, Color Tint)
        {
            this.Position = Position;
            this.Texture = Texture;
            this.Scale = Scale;
            this.Tint = Tint;
        }

        public void Draw(SpriteBatch batch)
        {
            //draw here
            batch.Draw(Texture, Hitbox, Tint);
        }
    }
}
