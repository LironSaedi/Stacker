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
            //row.Add()
            //add 3 moving objects
            //row.Add(new MovingObject())
        }

        //Alex is the best
        public void Update(int screenWidth)
        {
            //if any of the moving objects hit the left, move all to the right
            //vica versa
        }

    }
}
