using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Stacker
{

    //PascalCase: Class names, Function names, Public variables/properties
    //camelCase: private variables, local variables

    public class Game1 : Game
    {
        public static Texture2D pixel;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //FixedObject class: position, texture, scale, color, hitbox, Draw()
        //MovingObject : FixedObject + Speed, Update()

        //Row Class: List<MovingObjects>, Update(), Draw()



        Row row;
        List<FixedObject> fixedObjects; // null

        Rectangle Screen;
        KeyboardState ks;


        //Row object

        //when spacebar pressed:
        // 1. calculate which moving blocks to remove from row
        // 2. add fixedobjects to the location of the surviving row blocks
        // 3. move the row up

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });

            spriteBatch = new SpriteBatch(GraphicsDevice);
            Screen = GraphicsDevice.Viewport.Bounds;

            Texture2D image = Content.Load<Texture2D>("stacker cubes");

            //height of the screen - height of the block (image)

            //GraphicsDevice.Viewport.Height
            //Screen.Width




            row = new Row(image, new Vector2(0, Screen.Height - image.Height), Color.White, new Vector2(3, 0), Vector2.One);


            fixedObjects = new List<FixedObject>();


            
            for (int i = 0; i < GraphicsDevice.Viewport.Width / row.Image.Width ; i++)
            {
                fixedObjects.Add(new FixedObject(new Vector2(i*row.Image.Width , GraphicsDevice.Viewport.Height), row.Image, row[0].Scale, row[0].Tint));
            }
            //fixedObjects.Add(new FixedObject(Position,t))
        }


        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState lastKs = ks;
            ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Escape))
                Exit();



            row.Update(Screen.Width);
            if (ks.IsKeyDown(Keys.Space) && lastKs.IsKeyUp(Keys.Space)) // && space was previously released
            {
                //remove any moving objects from row that do NOT collide with any fixed objects

                // Ryan's error
                for (int i = 0; i < row.RowCount; i++)
                {
                    bool intersects = false;
                    for (int b = fixedObjects.Count - 1; b >= 0; b--)
                    {
                        if (row[i].Hitbox.Intersects(fixedObjects[b].Hitbox))
                        {
                            intersects = true;
                            break;
                        }
                    }

                    if (!intersects)
                    {
                        row.movingObjects.RemoveAt(i);
                        i--;
                    }
                }


                //add a fixed object for every moving object in the row
                for (int i = 0; i < row.RowCount; i++)
                {
                    fixedObjects.Add(new FixedObject(row[i].Position, row.Image, row[i].Scale, row[i].Tint));
                }
                row.MoveUp();
            }




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            for (int i = 0; i < fixedObjects.Count; i++)
            {
                fixedObjects[i].Draw(spriteBatch);
            }

            row.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
