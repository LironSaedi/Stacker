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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //FixedObject class: position, texture, scale, color, hitbox, Draw()
        //MovingObject : FixedObject + Speed, Update()

        //Row Class: List<MovingObjects>, Update(), Draw()



        Row row;
        List<FixedObject> fixedObjects;

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

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Screen = GraphicsDevice.Viewport.Bounds;


            // TODO: use this.Content to load your game content here

            Texture2D image = Content.Load<Texture2D>("stacker cubes");

            //height of the screen - height of the block (image)

            //GraphicsDevice.Viewport.Height
            //Screen.Width

            row = new Row(image, new Vector2(0, Screen.Height - image.Height), Color.White, new Vector2(3, 0));
            fixedObjects = new List<FixedObject>();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState lastKs = ks;
            ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Escape))
                Exit();



            row.Update(Screen.Width);
            if (ks.IsKeyDown(Keys.Space) && lastKs.IsKeyUp(Keys.Space)) // && space was previously released
            {
                //add a fixed object for every moving object in the row
                for (int i = 0; i < row.RowCount; i++)
                {
                    fixedObjects.Add(new FixedObject(row[i].Position, row.Image, row[i].Scale, row[i].Tint));
                }
                row.MoveUp();
            }





            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            for (int i = 0; i < fixedObjects.Count; i++)
            {
                fixedObjects[i ].Draw(spriteBatch);
            }

            row.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
