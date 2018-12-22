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
        private List<MovingObject> row;

        public MovingObject this[int index]
        {
            get
            {
                return row[index];
            }
        }

        public int RowCount
        {
            get
            {
                return row.Count;
            }
        }
        
        public Texture2D Image;


        public Row(Texture2D image, Vector2 position, Color tint, Vector2 speed) // image position color speed
        {
            row = new List<MovingObject>();
            this.Image = image;
            row.Add(new MovingObject(image, position, tint, speed));
            row.Add(new MovingObject(image, position + new Vector2(image.Width, 0), tint, speed));
            row.Add(new MovingObject(image, position + new Vector2(image.Width * 2, 0), tint, speed));
        }

        public void MoveUp()
        {
            //move all of the row objects up
            for (int i = 0; i < row.Count; i++)
            {
                row[i].Position.Y -= Image.Height;
            }
        }

        public void Update(int screenWidth)
        {

            for (int i = 0; i < row.Count; i++)
            {
                row[i].Update();
            }

            for (int i = 0; i < row.Count; i++)
            {
                if (row[i].Position.X + row[i].Texture.Width >= screenWidth || row[i].Position.X <= 0)
                {
                    for (int j = 0; j < row.Count; j++)
                    {
                        row[j].Speed.X *= -1;
                    }

                }
            }



            //if any of the moving objects hit the left, move all to the right
            //vica versa
        }

        public void Draw(SpriteBatch batch)
        {
            for (int i = 0; i < row.Count; i++)
            {
                row[i].Draw(batch);
            }
        }
        //  loop through row and 
    }
}
