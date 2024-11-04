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
        BasicEffect basicEffect;

        //Geometric info
        VertexPositionColor[] triangleVertices;
        VertexBuffer vertexBuffer;

        //Orbit
        bool orbit = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            //Setup Camera

            //BasicEffect
            basicEffect = new BasicEffect(GraphicsDevice);
            basicEffect.Alpha = 1f;

            // Want to see the colors of the vertices, this needs to be on
            //basicEffect.VertexColorEnabled = true;

            //Lighting requires normal information which VertexPositionColor does not have
            //If you want to use lighting and VPC you need to create a custom def
            basicEffect.LightingEnabled = false;

            //Geometry  - a simple triangle about the origin
            triangleVertices = new VertexPositionColor[6];
            triangleVertices[0] = new VertexPositionColor(new Vector3(
                0, 20, 0), Color.Red);
            triangleVertices[1] = new VertexPositionColor(new Vector3(
                -20, -20, 0), Color.Green);
            triangleVertices[2] = new VertexPositionColor(new Vector3(
                20, -20, 0), Color.Blue);
            
            triangleVertices[3] = new VertexPositionColor(new Vector3(
                20, 40, 0), Color.Red);
            triangleVertices[4] = new VertexPositionColor(new Vector3(
                0, 0, 0), Color.Green);
            triangleVertices[5] = new VertexPositionColor(new Vector3(
                40, 0, 0), Color.Blue);

            //Vert buffer
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(
                           VertexPositionColor), 6, BufferUsage.
                           WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(triangleVertices);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
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
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.SetVertexBuffer(vertexBuffer);

            //Turn off culling so we see both sides of our rendered triangle
            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            GraphicsDevice.RasterizerState = rasterizerState;

            foreach(EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 3);
            }
            
            base.Draw(gameTime);
        }
    }
}