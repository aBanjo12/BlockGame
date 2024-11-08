using System;
using BlockGame.Registry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BlockGame.Render;

/*
 *
 * 
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class Camera
{
    public Vector3 Position { get; private set; }
    public Vector3 Target { get; private set; }
    public Vector3 Up { get; private set; }
    public Matrix View { get; private set; }
    public Matrix Projection { get; private set; }

    private float yaw; // Rotation around the Y-axis (left/right)
    private float pitch; // Rotation around the X-axis (up/down)
    private float roll; // Rotation around the Z-axis (not used in this example)

    private float movementSpeed = 5f; // Camera movement speed
    private float rotationSpeed = 0.005f; // Camera rotation speed

    private Vector2 lastMousePosition;

    private BasicEffect basicEffect;
    public Camera(Vector3 startPosition, Vector3 startTarget, Vector3 startUp, GraphicsDevice device)
    {
        Position = startPosition;
        Target = startTarget;
        Up = startUp;

        View = Matrix.CreateLookAt(Position, Target, Up);
        Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 16f / 9f, 0.1f, 1000f);
        
        //BasicEffect
        basicEffect = new BasicEffect(device);
        basicEffect.Alpha = 1f;
        basicEffect.Texture = TextureRegistry.block;
        basicEffect.TextureEnabled = true;

        // Want to see the colors of the vertices, this needs to be on
        //basicEffect.VertexColorEnabled = true;

        //Lighting requires normal information which VertexPositionColor does not have
        //If you want to use lighting and VPC you need to create a custom def
        basicEffect.LightingEnabled = false;
    }

    public void Update(MouseState mouseState, KeyboardState keyboardState)
    {
        // Handle mouse movement for camera rotation
            var deltaX = mouseState.X - lastMousePosition.X;
            var deltaY = mouseState.Y - lastMousePosition.Y;

            yaw -= deltaX * rotationSpeed;
            pitch -= deltaY * rotationSpeed;

            pitch = MathHelper.Clamp(pitch, -MathHelper.PiOver2 + 0.1f, MathHelper.PiOver2 - 0.1f);

            // Update the last mouse position
            lastMousePosition = new Vector2(mouseState.X, mouseState.Y);
        

        // Handle keyboard input for camera movement
        if (keyboardState.IsKeyDown(Keys.W)) Position += Vector3.Transform(Vector3.Forward, Matrix.CreateFromYawPitchRoll(yaw, pitch, roll)) * movementSpeed;
        if (keyboardState.IsKeyDown(Keys.S)) Position -= Vector3.Transform(Vector3.Forward, Matrix.CreateFromYawPitchRoll(yaw, pitch, roll)) * movementSpeed;
        if (keyboardState.IsKeyDown(Keys.A)) Position -= Vector3.Transform(Vector3.Right, Matrix.CreateFromYawPitchRoll(yaw, pitch, roll)) * movementSpeed;
        if (keyboardState.IsKeyDown(Keys.D)) Position += Vector3.Transform(Vector3.Right, Matrix.CreateFromYawPitchRoll(yaw, pitch, roll)) * movementSpeed;

        // Update the camera's target based on the yaw and pitch
        var forward = Vector3.Transform(Vector3.Forward, Matrix.CreateFromYawPitchRoll(yaw, pitch, roll));
        Target = Position + forward;

        // Update the view matrix
        View = Matrix.CreateLookAt(Position, Target, Up);
    }

    public void ResetMousePosition(int screenWidth, int screenHeight)
    {
        lastMousePosition = new Vector2(screenWidth / 2, screenHeight / 2);
        Mouse.SetPosition(screenWidth / 2, screenHeight / 2);
    }
    
    public void Draw(GraphicsDevice device, VertexBuffer vertexBuffer)
    {
        device.Clear(Color.CornflowerBlue);

        basicEffect.Projection = Projection;
        basicEffect.View = View;
        foreach(EffectPass pass in basicEffect.CurrentTechnique.Passes)
        {
            pass.Apply();
            device.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount);
        }
    }
}