using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlockGame;

public class Camera
{
    public Vector3 camTarget;
    public Vector3 camPosition;
    public Matrix projectionMatrix;
    public Matrix viewMatrix;
    public Matrix worldMatrix;

    public Camera(GraphicsDevice device)
    {
        camTarget = new Vector3(0f, 0f, 0f);
        camPosition = new Vector3(0f, 0f, -100f);
        projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), 
            device.DisplayMode.AspectRatio, 1f, 1000f);
        viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, new Vector3(0f, 1f, 0f));// Y up
        worldMatrix = Matrix.CreateWorld(camTarget, Vector3.Forward, Vector3.Up);
    }

    public void Update()
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            camPosition.X -= 1f;
            camTarget.X -= 1f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            camPosition.X += 1f;
            camTarget.X += 1f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            camPosition.Y -= 1f;
            camTarget.Y -= 1f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            camPosition.Y += 1f;
            camTarget.Y += 1f;
        }
        if(Keyboard.GetState().IsKeyDown(Keys.W))
        {
            camPosition.Z += 1f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.S))
        {
            camPosition.Z -= 1f;
        }
        viewMatrix = Matrix.CreateLookAt(camPosition, camTarget, Vector3.Up);
    }
    
    public void Draw(GraphicsDevice device)
    {
        basicEffect.Projection = projectionMatrix;
        basicEffect.View = viewMatrix;
        basicEffect.World = worldMatrix;
        device.Clear(Color.CornflowerBlue);
    }
}