using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker
{
    class Row
    {
        public List<MovingObject> movingObjects;

        public MovingObject this[int index]
        {
            get
            {
                return movingObjects[index];
            }
        }

        public int RowCount
        {
            get
            {
                return movingObjects.Count;
            }
        }
        
        public Texture2D Image;

        

        public Row(Texture2D image, Vector2 position, Color tint, Vector2 speed, Vector2 scale) // image position color speed
        {
            movingObjects = new List<MovingObject>();
            this.Image = image;
            movingObjects.Add(new MovingObject(image, position, tint, speed, scale));
            movingObjects.Add(new MovingObject(image, position + new Vector2(image.Width, 0), tint, speed, scale));
            movingObjects.Add(new MovingObject(image, position + new Vector2(image.Width * 2, 0), tint, speed, scale));
        }

        public void MoveUp()
        {
            //move all of the row objects up
            for (int i = 0; i < movingObjects.Count; i++)
            {
                movingObjects[i].Position.Y -= Image.Height;
            }
        }

        public void Update(int screenWidth)
        {
            for (int i = 0; i < movingObjects.Count; i++)
            {
                movingObjects[i].Update();
            }

            for (int i = 0; i < movingObjects.Count; i++)
            {
                if (movingObjects[i].Position.X + movingObjects[i].Texture.Width >= screenWidth || movingObjects[i].Position.X <= 0)
                {
                    for (int j = 0; j < movingObjects.Count; j++)
                    {
                        movingObjects[j].Speed.X *= -1;
                    }

                }
            }            
            //if any of the moving objects hit the left, move all to the right
            //vica versa
        }

        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < movingObjects.Count; i++)
            {
                movingObjects[i].Draw(batch);
            }
        }
        //  loop through row and 
    }
}
