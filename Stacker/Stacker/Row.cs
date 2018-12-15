using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacker
{
    class Row
    {

        List<MovingObject> row = new List<MovingObject>();

        public Row(Texture2D image, Vector2 position, Color tint, Vector2 speed) // image position color speed
        {
            row.Add(new MovingObject(image, position, tint, speed));
            row.Add(new MovingObject(image, position + new Vector2(image.Width, 0), tint, speed));
            row.Add(new MovingObject(image, position + new Vector2(image.Width * 2, 0), tint, speed));
            
            //row.Add(new MovingObject())
        }

        public void Update(int screenWidth)
        {

            for (int i = 0; i < row.Count; i++)
            {
                if (row[i].Position.X >= screenWidth)
                {
                    for (int j = 0; j < row.Count; j++)
                    {
                        row[j].Speed.X = -Math.Abs(row[j].Speed.X);
                    }
                    
                }
              }  
                    //if any of the moving objects hit the left, move all to the right
            //vica versa
        }

        //Draw
        //  loop through row and 
    }
}
