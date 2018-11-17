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
    class MovingObject
    {
        Vector2 Position;
        Color color;
        Texture2D texture;
        Vector2 Scale;
        Vector2 Speed;
        int Score;
        Collider Hitbox


        public MovingObject(Texture2D image, Vector2 position, Color color, Vector2 speed)
        {
            this.Speed = speed;
            Score = 0;

            Hitbox = new Collider(texture, Position + new Vector2(texture.Width * Scale.X / 2, texture.Height * Scale.Y / 2));
        }

    }
}

