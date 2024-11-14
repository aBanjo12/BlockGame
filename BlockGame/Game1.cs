using BlockGame.Event;
using BlockGame.Registry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlockGame
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Camera
        

        //BasicEffect for rendering

        //Geometric info
        private VertexPositionColor[] triangleVertices;

        //Orbit
        bool orbit = false;

        private World.World world;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
            base.Initialize();

            //Setup Camera
            

            //Geometry  - a simple triangle about the origin
            // triangleVertices = new VertexPositionColor[6];
            // triangleVertices[0] = new VertexPositionColor(new Vector3(
            //     0, 20, 0), Color.Red);
            // triangleVertices[1] = new VertexPositionColor(new Vector3(
            //     -20, -20, 0), Color.Green);
            // triangleVertices[2] = new VertexPositionColor(new Vector3(
            //     20, -20, 0), Color.Blue);
            //
            // triangleVertices[3] = new VertexPositionColor(new Vector3(
            //     20, 40, 0), Color.Red);
            // triangleVertices[4] = new VertexPositionColor(new Vector3(
            //     0, 0, 0), Color.Green);
            // triangleVertices[5] = new VertexPositionColor(new Vector3(
            //     40, 0, 0), Color.Blue);

            //Vert buffer
            
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            world = new World.World(GraphicsDevice);

            TextureRegistry.block = Content.Load<Texture2D>("block");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                Keys.Escape))
                Exit();

            // if (orbit)
            // {
            //     Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(1f));
            //     camPosition = Vector3.Transform(camPosition, 
            //                   rotationMatrix);
            // }
            world.Update();
            EventHandler.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Turn off culling so we see both sides of our rendered triangle
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rasterizerState;
            
            world.Draw(GraphicsDevice, spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}